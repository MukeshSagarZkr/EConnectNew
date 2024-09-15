namespace UserMicroservice.Repository
{
    public interface ILoginRepository
    {
        IEnumerable<Login> GetAllLogins();
        Login? GetLoginByName(string name);
        Login? GetLoginById(int id);
        void AddLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(int id);
        IEnumerable<Login> GetAllActiveLogins();
        IEnumerable<Login> GetAllActiveLoginsByCompanyId(string id);
    }
}
