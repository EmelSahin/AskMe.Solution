using AskMe.Business;
using AskMe.DataAccessLayer.Concrete.EntityFramework.Repository;
using AskMe.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AskMe.MvcUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBllBinds();
        }

        private void AddBllBinds()
        {
            this.kernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryRepository", new EfCategoryRepository());
            this.kernel.Bind<IUserService>().To<UserManager>().WithConstructorArgument("userRepository", new EfUserRepository());
            this.kernel.Bind<IQuestionService>().To<QuestionManager>().WithConstructorArgument("questionRepository", new EfQuestionRepository());

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
}