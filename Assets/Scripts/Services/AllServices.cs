using Assets.Scripts.Infrastructure.Services;

public class AllServices
{
    private static AllServices _instance;

    public static AllServices Container => _instance ?? (_instance = new AllServices());

    public void RegisterService<TService>(TService implemintation) where TService : IService => 
        Implementation<TService>.ServiceInstance = implemintation;

    public TService Service<TService>() where TService : IService =>
        Implementation<TService>.ServiceInstance;

    private static class Implementation<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}
