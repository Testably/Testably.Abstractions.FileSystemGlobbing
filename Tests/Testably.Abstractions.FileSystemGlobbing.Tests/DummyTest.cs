namespace Testably.Abstractions.FileSystemGlobbing.Tests;

public class DummyTest
{
	[Fact]
	public async Task MyDummyTest()
	{
		await That(1).IsGreaterThan(0);
	}
}
