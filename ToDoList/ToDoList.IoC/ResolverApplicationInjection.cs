using Microsoft.Extensions.DependencyInjection;
using ToDoList.Api.Interfaces;
using ToDoList.Data;
using ToDoList.Data.Base;

namespace ToDoList.IoC
{
    public static class ResolverApplicationInjection
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IBoardRepository, BoardRepository>();
            services.AddSingleton<IContext, ToDoListContext>();
        }
    }
}