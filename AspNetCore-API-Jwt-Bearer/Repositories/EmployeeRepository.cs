using AspNetCore_API_Jwt_Bearer.Entities;

namespace AspNetCore_API_Jwt_Bearer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees = new List<Employee>()
        {
            new(){Id = 1, FirstName ="Ali", LastName="Uçar" , BeginDate=new DateOnly(),Phone="5316985241", Email="ali@gmail.com"},
            new(){Id = 2, FirstName ="Oya", LastName="Koşar" , BeginDate=new DateOnly(),Phone="5315874125", Email="oya@gmail.com"},
            new(){Id = 3, FirstName ="Neşe", LastName="Sever" , BeginDate=new DateOnly(),Phone="5319854514", Email="nese@gmail.com"},
            new(){Id = 4, FirstName ="Hasan", LastName="Kaya" , BeginDate=new DateOnly(),Phone="5319853621", Email="hasan@gmail.com"}
        };
        public Employee GetById(int id)
        {
            return _employees.Find(x => x.Id == id)!;
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }
        public Employee Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

      

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
