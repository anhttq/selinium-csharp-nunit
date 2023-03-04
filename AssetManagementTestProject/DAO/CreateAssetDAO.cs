namespace AssetManagementTestProject.DAO;

public class CreateAssetDAO
{
    public partial class CreateAssetUI
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public string Specification { get; private set; }
        public string InstalledDate { get; private set; }
        public string State { get; private set; }
        public CreateAssetUI(string name, string category, 
        string specification, string installedDate, string state)
        {
            Name = name;
            Category = category;
            Specification = specification;
            InstalledDate = installedDate;
            State = state;
        }
    }
}

