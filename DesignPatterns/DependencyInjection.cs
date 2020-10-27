using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{

	/// <summary>
	/// The Dependency Injection is a design pattern that allows us to develop loosely coupled software components. 
	/// In other words, we can say that this design pattern is used to reduce the tight coupling between the software components. 
	/// As a result, we can easily manage future changes and other complexity in our application.
	/// </summary>
	class DependencyInjection
	{

	}


	public class Employee
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Department { get; set; }
	}

	public interface IEmployeeDAL
	{
		List<Employee> SelectAllEmployees();
	}

	public class EmployeeDAL : IEmployeeDAL
	{
		public List<Employee> SelectAllEmployees()
		{
			throw new NotImplementedException();
		}
	}

	// Constructor Injection
	public class EmployeeBL_Constructor
	{
		public IEmployeeDAL employeeDAL;
		public EmployeeBL_Constructor(IEmployeeDAL employeeDAL)
		{
			this.employeeDAL = employeeDAL;
		}
		public List<Employee> GetAllEmployees()
		{
			return employeeDAL.SelectAllEmployees();
		}
	}

	//Property Injection
	public class EmployeeBL_Property
	{
		private IEmployeeDAL employeeDAL;

		public IEmployeeDAL employeeDataObject
		{
			set
			{
				this.employeeDAL = value;
			}
			get
			{
				if (employeeDataObject == null)
				{
					throw new Exception("Employee is not initialized");
				}
				else
				{
					return employeeDAL;
				}
			}
		}

		public List<Employee> GetAllEmployees()
		{
			return employeeDAL.SelectAllEmployees();
		}
	}

	public class PropertyInjection
	{
		public void Initiallize()
		{
			EmployeeBL_Property employeeBL = new EmployeeBL_Property();
			employeeBL.employeeDataObject = new EmployeeDAL();

			employeeBL.GetAllEmployees();
		}
	}


	//Method Injection
	public class EmployeeBL_Method
	{
		public IEmployeeDAL employeeDAL;

		public List<Employee> GetAllEmployees(IEmployeeDAL _employeeDAL)
		{
			employeeDAL = _employeeDAL;
			return employeeDAL.SelectAllEmployees();
		}
	}

}
