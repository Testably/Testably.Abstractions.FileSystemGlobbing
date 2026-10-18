# Contributor guide

## Pull requests
**Pull requests are welcome!**  
Please include a clear description of the changes you have made with your request. The title should follow the [conventional commits](https://www.conventionalcommits.org/en/v1.0.0/) guideline with one of the following [prefixes](https://github.com/conventional-changelog/commitlint/tree/master/%40commitlint/config-conventional):
- `feat:` A new feature
- `fix:` A bug fix
- `docs:` Documentation only changes
- `style:` Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- `refactor:` A code change that neither fixes a bug nor adds a feature
- `perf:` A code change that improves performance
- `test:` Adding missing tests or correcting existing tests
- `build:` Changes that affect the build system or external dependencies
- `ci:` Changes to our CI configuration files and scripts
- `chore:` Other changes that don't modify src or test files
- `revert:` Reverts a previous commit

All code should be covered by unit tests and comply with the coding guideline in this project.

**Technical expectation**  
As a framework for supporting unit testing, this project has a high standard for testing itself.  
In order to support this, static code analysis is performed using [SonarCloud](https://sonarcloud.io/project/overview?id=Testably_Testably.Abstractions.FileSystemGlobbing) with quality gate requiring to  
- solve all issues reported by SonarCloud
- have a code coverage of > 90%

## Building and testing

`dotnet build Testably.Abstractions.FileSystemGlobbing.sln` builds everything; `./build.ps1 UnitTests` (or `./build.sh UnitTests`) runs the unit tests like the CI, and `./build.ps1 ApiChecks` the public API tests.

All tests run on [TUnit](https://tunit.dev) and the Microsoft.Testing.Platform, which `global.json` selects for `dotnet test`. Pass the project with `--project` and filter with `--treenode-filter`:

```shell
dotnet test
dotnet test --project Tests/Testably.Abstractions.FileSystemGlobbing.Tests -f net8.0
dotnet test --project Tests/Testably.Abstractions.FileSystemGlobbing.Tests -f net8.0 --treenode-filter "/*/*/DummyTest/*"
```

The public API tests in `Tests/Api/Testably.Abstractions.FileSystemGlobbing.Api.Tests` compare the public API with the files in its `Expected` folder. To accept an intentional change, run the explicit test `AcceptApiChanges` on purpose and commit the updated files:

```shell
dotnet test --project Tests/Api/Testably.Abstractions.FileSystemGlobbing.Api.Tests --treenode-filter "/*/*/ApiAcceptance/*"
```

A normal run skips `AcceptApiChanges`, because it is `[Explicit]`; TUnit only runs it when every test that the filter selects is explicit.
