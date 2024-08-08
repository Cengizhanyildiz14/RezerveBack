using Autofac;
using Business.Concrete;
using Business.Interfaces;
using Core.Jwt;
using DataAccess.Dal;
using DataAccess.IDal;

namespace Business
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<AppointmentService>().As<IAppointmentService>();
            builder.RegisterType<AppointmentDal>().As<IAppoinmentDal>();

            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<RoleDal>().As<IRoleDal>();

            builder.RegisterType<DuyuruService>().As<IDuyuruService>();
            builder.RegisterType<DuyuruDal>().As<IDuyuruDal>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<TokenHelper>();
        }
    }
}
