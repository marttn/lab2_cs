namespace lab2_cs.Tools.Navigation
{
    internal enum ViewType
    {
        CreatePerson,
        PersonInfo
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
