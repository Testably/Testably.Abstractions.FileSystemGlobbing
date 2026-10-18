using aweXpect;
using System.Threading.Tasks;
using static aweXpect.Expect;

namespace Testably.Abstractions.FileSystemGlobbing.Api.Tests;

/// <summary>
///     Whenever a test fails, this means that the public API surface changed.
///     If the change was intentional, execute the <see cref="ApiAcceptance.AcceptApiChanges()" /> test to take over the
///     current public API surface. The changes will become part of the pull request and will be reviewed accordingly.
/// </summary>
public sealed class ApiApprovalTests
{
	[Test]
	[MethodDataSource(typeof(Helper), nameof(Helper.GetTargetFrameworks))]
	public async Task VerifyPublicApiForTestablyAbstractionsFileSystemGlobbing(string framework)
	{
		const string assemblyName = "Testably.Abstractions.FileSystemGlobbing";

		string publicApi = Helper.CreatePublicApi(framework, assemblyName);
		string expectedApi = Helper.GetExpectedApi(framework, assemblyName);

		await That(publicApi).IsEqualTo(expectedApi);
	}
}
