using System.Web.Mvc;
using TaskManagement.Repository.Interface.ITeacherInterface;
using TaskManagement.Repository.Services.TeacherServices;
using Unity;
using Unity.Mvc5;

namespace TaskManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITeachersInterface, TeacherServices>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}