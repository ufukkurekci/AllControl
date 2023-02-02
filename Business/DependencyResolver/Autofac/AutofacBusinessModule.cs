using Autofac;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Entites;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /// <summary>
            /// Manager Instance area
            /// </summary>
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserRoleManager>().As<IUserRoleService>().SingleInstance();
            builder.RegisterType<DailyToDoManager>().As<IDailyToDoService>().SingleInstance();
            builder.RegisterType<ToDoManager>().As<IToDoService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            /// <summary>
            /// Manager Instance area
            /// </summary>
            /// 
            /// 
            /// <summary>
            /// Dal Instance area
            /// </summary>
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfUserRoleDal>().As<IUserRoleDal>().SingleInstance();
            builder.RegisterType<EfToDoDal>().As<IToDoDal>().SingleInstance();
            builder.RegisterType<EfDailyToDoDal>().As<IDailyToDoDal>().SingleInstance();
            /// <summary>
            /// Dal Instance area
            /// </summary>
            /// 

            builder.RegisterType<AllControlContext>().SingleInstance();
            builder.RegisterType<User>().As<IUser>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
