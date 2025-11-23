## Program.cs 변수 실정
LICENSE_CHECK = "0";  // 라이센스 파일 체크 및 검증 안함
LICENSE_CHECK = "1";  // 라이센스 파일 체크 및 검증 (기본값)

프로그램을 처음에 로딩을 할 때 실행 폴더에서 license.lic를 찾음
PASS_PHRASE = "DASUNTECH.inc" 사용해서 license 파일을 디코딩함
license.lic에 있는 (1) Volume No가 프로그램이 설치된 PC의 Volume no와 같은지를 확인하고, (2) Expiry Date가 지나지 않았는지를 확인함
- Volume No(형식 : XXXX-XXXX)가 다르면 "라이센스 오류: 잘못된 볼륨 번호" 메시지를 출력하고 프로그램을 종료함
- Expiry Date(형식 : YYYY-MM-DD)가 지났으면 "라이센스 오류: 라이센스 기간 만료" 메시지를 출력하고 프로그램을 종료함 

## license.lic 암호화 파라미터
- 패스프레이즈(예시): `DASUNTECH.inc` (현재 구현에서는 하드코딩되어 있음)
  - 보안상 하드코딩 금지(권장 대체: 환경 변수, OS 키 저장소, 비밀 관리 서비스)
- Salt: 16 바이트 랜덤
- PBKDF2: `Rfc2898DeriveBytes` (반복 횟수: 100000, HMAC-SHA1 기본)
- 파생 키 길이: 32 바이트 (256비트)
- 대칭 암호: AES-256
  - 모드: CBC
  - 블록 크기: 128
  - 패딩: PKCS7
- IV: AES에서 생성한 16 바이트

## license.lic 파일 포맷 (바이트 순서)
- `[salt (16 bytes)] [iv (16 bytes)] [ciphertext (... bytes)]`
- 파일은 바이너리로 저장됩니다.

## license.lic 검증(복호화) 절차 (요약)
1. `license.lic` 존재 여부 및 최소 길이(32 bytes) 검사
2. 파일에서 salt(16), iv(16), cipher 분리
3. PBKDF2(passphrase, salt, 100000)로 키 파생
4. AES-CBC로 복호화하여 UTF-8 평문 획득
5. 평문 파싱(정규식 또는 JSON)로 `VOL` 및 `EXP` 추출
6. `VOL` 비교(대소문자 무시, 코드 참조) 및 `EXP`와 현재 날짜 비교

# 확인방법
// 사용자 요청: 복호화된 license에서 추출한 값을 메시지로 출력
try
{
    MessageBox.Show($"라이센스 정보:\n볼륨 번호: {fileVolume}\n만료 날짜: {expiryStr}", "라이센스 정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
catch
{
    // 메시지 박스 표시 실패시 무시하고 검증은 계속
}

## 라이센스관련 루틴을 별도의 license_module.cs 파일로 분리
- 라이센스 검증 관련 코드를 Program.cs에서 license_module.cs로 이동하여 모듈화
- Program.cs에서는 license_module.cs의 함수를 호출하여 라이센스 검증 수행
- license_module.cs 파일에는 라이센스 검증에 필요한 모든 함수와 상수가 포함
- 이 구조는 라이센스 검증 로직을 독립적으로 관리할 수 있게 하여 향후 변경이나 확장이 용이함

## 다른 프로그램에서 `license_module.cs` 사용 방법

다른 프로젝트나 프로그램에서 `license_module.cs`에 구현된 라이센스 검증 기능을 사용하려면 다음 변수와 함수를 호출하면 됩니다.

- 주요 함수/속성
  - `LicenseModule.VerifyLicense(string licenseFilePath = null)`
    - 설명: 지정된 경로(또는 기본 실행 폴더의 `license.lic`)에서 라이센스 파일을 읽고 복호화 + 검증을 수행합니다.
    - 동작: 검증에 실패하면 `LicenseModule.LicenseException` 예외를 던집니다. 성공하면 내부 속성에 값이 설정됩니다.
  - `LicenseModule.LicenseVolume` (string)
    - 설명: 검증된 라이센스의 볼륨 번호(예: `XXXX-XXXX`)를 읽을 수 있습니다.
  - `LicenseModule.LicenseExpiry` (DateTime?)
    - 설명: 검증된 라이센스의 만료 날짜를 `DateTime`으로 제공합니다. 파싱 실패 시 `null`이 될 수 있습니다.
  - 예외 타입: `LicenseModule.LicenseException`
    - 설명: 검증 실패 사유(파일 없음, 복호화 실패, 볼륨 불일치, 만료 등)를 메시지로 포함합니다.

- 간단 사용 예시

```csharp
try
{
    // 기본 위치(실행 폴더/license.lic)를 사용하여 검증
    LicenseModule.VerifyLicense();

    // 검증 성공 시 정보 사용
    string vol = LicenseModule.LicenseVolume;
    DateTime? expiry = LicenseModule.LicenseExpiry;
    // ... 필요 시 UI에 표시하거나 로직에서 사용
}
catch (LicenseModule.LicenseException ex)
{
    // 검증 실패시 프로그램 종료
    // MessageBox.Show(ex.Message, "라이센스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
    Environment.Exit(1);
    return;
}
```

- 추가 옵션 및 참고
  - `VerifyLicense`에 `licenseFilePath`를 전달하면 특정 파일 경로의 라이센스 파일을 사용하여 검증합니다.
  - 현재 구현은 검증 과정에서 라이센스 정보를 `MessageBox`로 표시합니다(디버그/사용자용). UI 표시를 원치 않으면 `license_module.cs`의 해당 코드를 제거하거나 수정하세요.
  - `PASS_PHRASE` 등 일부 상수는 `license_module.cs` 안에 하드코딩되어 있습니다. 보안 요구사항이 있으면 해당 값을 환경 변수나 OS 비밀 저장소로 옮기는 것을 권장합니다.

이 섹션을 다른 문서나 배포 가이드에 포함하여 외부 애플리케이션에서 모듈을 어떻게 호출하는지 안내할 수 있습니다.

## NuGet 패키지로 변환 및 배포 (LicenseModule 재사용)

라이센스 관련 모듈을 다른 프로젝트에서 쉽고 안전하게 재사용하려면 `license_module.cs`를 별도의 Class Library로 만들고 NuGet 패키지로 배포하는 것이 좋습니다. 아래는 권장 절차, 예제 및 소비자 사용 방법입니다.

1) 패키지로 만들기 전 권장 리팩터링
- `LicenseModule`을 `public` 클래스로 변경하고 정적 API 대신 인스턴스형 서비스(`ILicenseService` 인터페이스)를 제공하세요. 이렇게 하면 의존성 주입(DI)과 단위 테스트가 쉬워집니다.
- UI 호출(`MessageBox`) 같은 부작용은 제거하고, 결과는 DTO(예: `LicenseInfo`) 또는 예외로 반환하세요.
- 민감 값(`PASS_PHRASE`, PBKDF2 반복 수 등)은 생성자 파라미터, 구성(예: `IConfiguration`) 또는 환경변수로 주입하도록 변경하세요.

간단한 권장 API 설계 예제:

```csharp
public interface ILicenseService
{
    LicenseInfo VerifyLicense(string licenseFilePath = null);
}

public class LicenseInfo
{
    public string Volume { get; set; }
    public DateTime? Expiry { get; set; }
}

public class LicenseException : Exception { public LicenseException(string msg):base(msg){} }

public class LicenseService : ILicenseService
{
    public LicenseInfo VerifyLicense(string licenseFilePath = null)
    {
        // 검증 수행. 실패 시 LicenseException throw
        // 성공 시 LicenseInfo 반환
    }
}
```

2) Class Library(.NET Framework 4.7.2) 프로젝트 생성
- Visual Studio에서 새 프로젝트 → `Class Library (.NET Framework)` 생성하고 Target Framework를 `.NET Framework 4.7.2`로 설정합니다.
- `license_module.cs`를 이 프로젝트로 이동하고 public/인스턴스 기반 API로 리팩터링합니다.
- XML 문서 주석을 추가하면 패키지 소비자가 문서를 쉽게 볼 수 있습니다.

3) 패키지 메타데이터 준비 (`.nuspec` 또는 SDK-style csproj)
- 전통적인 방법: `LicenseModule.nuspec` 파일 생성 (아래 예제)
- SDK-style 프로젝트인 경우 `Package` 관련 속성을 csproj에 추가하고 `dotnet pack` 사용 가능(하지만 .NET Framework 4.7.2 프로젝트가 SDK-style인지 확인 필요)

예제 `LicenseModule.nuspec`:

```xml
<?xml version="1.0"?>
<package>
  <metadata>
    <id>Company.LicenseModule</id>
    <version>1.0.0</version>
    <authors>YourName</authors>
    <owners>YourCompany</owners>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>License verification module (AES-256 PBKDF2) for Serial_Program.</description>
    <tags>license encryption aes pbkdf2</tags>
    <dependencies>
      <!-- 필요 시 의존성 추가 -->
    </dependencies>
  </metadata>
  <files>
    <file src="bin\Release\LicenseModule.dll" target="lib\net472\" />
  </files>
</package>
```

4) 패키징 및 배포
- nuget.exe를 사용하는 경우:
  1. 프로젝트를 Release로 빌드하여 `LicenseModule.dll` 생성
  2. `nuget pack LicenseModule.nuspec` 실행하여 `.nupkg` 생성
  3. `nuget push YourPackage.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey <NUGET_KEY>`로 배포
- SDK-style(또는 .NET Core SDK 설치된 경우):
  - `dotnet pack -c Release` (패키지 메타데이터가 csproj에 있으면 .nupkg 생성)
  - `dotnet nuget push` 또는 `nuget push`로 배포

5) 패키지 소비(다른 프로젝트에서 사용)
- Visual Studio의 NuGet 패키지 관리자에서 설치
- 또는 Package Manager Console:
  - `Install-Package Company.LicenseModule -Version 1.0.0`
- 사용 예시:

```csharp
// DI 없이 직접 사용
var svc = new LicenseService(/* passphrase or config */);
try
{
    var info = svc.VerifyLicense();
    Console.WriteLine($"Volume: {info.Volume}, Expiry: {info.Expiry}");
}
catch (LicenseException ex)
{
    // 처리
}

// DI 등록 예시 (Autofac/Microsoft DI 등 사용 가능)
// services.AddSingleton<ILicenseService>(new LicenseService(config));
```

6) 보안 및 배포 권장 사항
- 패스프레이즈를 소스 코드에 하드코딩하지 마세요. 배포 시 환경변수/키 저장소 사용 권장.
- 가능하면 서명된 패키지(코드 서명)로 배포하세요.
- API 변경 시 Major 버전 정책(SemVer)을 따르세요.

7) 추가 파일(권장)
- `LICENSE` 파일: 오픈소스 배포 시 라이선스 표기
- `CHANGELOG.md`: 버전별 변경 기록
- `README.md`(패키지용): 간단 사용법과 구성 옵션

이 가이드를 따라 `LicenseModule`을 NuGet 패키지로 만들면 여러 애플리케이션에서 일관되게 사용하고 보안/업데이트를 중앙에서 관리할 수 있습니다.

## 변경 사항 요약 (최근 리팩터링)

최근 작업에서는 내부에 구현되어 있던 라이센스 관련 코드를 제거하고, 라이센스 검증을 재사용 가능한 NuGet 패키지로 전환했습니다. 적용된 주요 변경 사항은 다음과 같습니다.

- 로컬 파일 `license_module.cs` 삭제: 내부에 하드코딩된 복호화/검증 구현을 제거했습니다.
- `Program.cs`에서 내장 라이센스 검사 로직 제거: 프로그램 진입점은 이제 단순히 애플리케이션을 시작합니다. (라이센스 검사는 외부 패키지 호출로 처리)
- `Form1.cs`에서 `Program.LicenseVolume` / `Program.LicenseExpiry` 직접 참조 제거: 라이센스 상태 표시는 NuGet 패키지의 API를 통해 필요 시 직접 호출하도록 변경했습니다.
- `LicenseModule`은 별도 NuGet 패키지(또는 외부 라이브러리)로 분리되어 재사용됩니다.

이 변경은 라이센스 로직을 중앙에서 관리하고 여러 애플리케이션에서 동일한 구현을 공유하기 위함입니다.

## NuGet 패키지(라이센스 서비스) 사용 방법 예제

NuGet으로 배포된 라이센스 모듈(예: `Company.LicenseModule`)을 프로젝트에 설치한 뒤, 폼 초기화 시 라이센스 상태를 표시하려면 아래와 같이 사용하세요. (패키지의 실제 네임스페이스/클래스 이름은 배포된 패키지에 따라 달라질 수 있습니다.)

```csharp
using Company.LicenseModule; // 실제 네임스페이스로 변경

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        InitializeUi();

        // 예: 폼 로드 시 라이센스 검증 및 상태 표시
        TryShowLicenseStatus();
    }

    private void TryShowLicenseStatus()
    {
        try
        {
            // 생성자에서 패스프레이즈를 주입하거나 환경변수로 설정 가능
            var svc = new LicenseService(); // 또는 new LicenseService(passphrase)
            var info = svc.VerifyLicense(); // 검증 실패 시 LicenseException throw

            tslVolume.Text = $"볼륨: {info.Volume}";
            tslExpiry.Text = info.Expiry.HasValue ? $"만료일: {info.Expiry.Value:yyyy-MM-dd}" : "만료일: 알수없음";
        }
        catch (LicenseException ex)
        {
            // 검증 실패 처리
            MessageBox.Show(ex.Message, "라이센스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // 필요시 애플리케이션 종료
            // Application.Exit();
        }
    }
}
```

주의사항:
- 패키지의 타입/네임스페이스는 실제로 배포한 NuGet 패키지 구현에 맞춰 사용하세요.
- 보안상 패스프레이즈는 소스 코드에 하드코딩하지 말고, 생성자 인자나 환경변수(`LICENSE_PASSPHRASE`) 등으로 주입하세요.
- 패키지 API는 예외(`LicenseException`)를 이용해 실패 원인을 제공합니다.

## 이전 로컬 구현 관련 참고

- 내부 구현이 제거되었으므로, 이전에 사용하던 `license_module.cs` 또는 `Program` 내의 복호화 코드에 더 이상 의존하지 마세요.
- 필요 시, 로컬에서 바로 사용하려면 NuGet 패키지 대신 새로 만든 `LicenseService` 구현을 소스에 포함시키거나, 기존 백업 코드를 복원해야 합니다.

---

원하면 제가 실제 사용 중인 NuGet 패키지 네임스페이스로 위 예제를 맞춰 드리거나, Form1에 자동으로 라이센스 표시 코드를 삽입해 드리겠습니다.