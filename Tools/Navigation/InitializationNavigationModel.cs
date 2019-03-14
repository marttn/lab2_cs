using System;
using lab2_cs.Views;
using PersonInfoView = lab2_cs.Views.PersonInfoView;
using CreatePersonView = lab2_cs.Views.CreatePersonView;
namespace lab2_cs.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            
        }
   
        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.CreatePerson:
                    ViewsDictionary.Add(viewType, new CreatePersonView());
                    break;
                case ViewType.PersonInfo:
                    ViewsDictionary.Add(viewType, new PersonInfoView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
