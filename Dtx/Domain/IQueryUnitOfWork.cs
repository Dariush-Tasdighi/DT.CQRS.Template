namespace Dtx.Domain
{
	public interface IQueryUnitOfWork : System.IDisposable
	{
		bool IsDisposed { get; }
	}
}
