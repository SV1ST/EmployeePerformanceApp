using ClosedXML.Excel;
using EmployeePerformanceApp.Models;
using EmployeePerformanceApp.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerformanceApp.Service
{
    public class SelectionService : ISelectionService
    {
        //Repositories
        private readonly ISelectionRepository _selectionRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public SelectionService(ISelectionRepository selectionRepository,
                                IParameterRepository parameterRepository,
                                IDepartmentRepository departmentRepository,
                                IUserRepository userRepository,
                                IHttpContextAccessor httpContextAccessor)
        {
            _selectionRepository = selectionRepository;
            _parameterRepository = parameterRepository;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateSelectionForDB(int departmentId, string selectionName)
        {
            

            Selection selection = new Selection { DepartmentId = departmentId, SelectionName = selectionName/*, Parameters = parametersArray*/ };
            await _selectionRepository.AddSelectionForDB(selection);
        }
        public async Task AddParameterToSelection(int []arr,int idSelection)
        {
            Selection selection = await _selectionRepository.GetSelectionById(idSelection);
            List<Parameter> parametersArray = new List<Parameter>(await _parameterRepository.GetParametersByAllId(arr));
            selection.Parameters = parametersArray;
            await _selectionRepository.Save();
        }

        public async Task<CreateSelectionViewModel> CreateSelectionShowSevice(int chosenDepartmentId)
        {
            CreateSelectionViewModel createSelectionViewModel = new CreateSelectionViewModel();
            createSelectionViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            createSelectionViewModel.Selections = await _selectionRepository.GetAllDataSelection();
            createSelectionViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            createSelectionViewModel.CurrentDepartmentID = chosenDepartmentId;
            return (createSelectionViewModel);
        }

        public async Task<CreateSelectionViewModel> CreateSelectionAction(int selectionID, string selectionName, int chosenDepartmentId)
        {
            CreateSelectionViewModel createSelectionViewModel = new CreateSelectionViewModel();
            createSelectionViewModel.Parameters = await _parameterRepository.GetAllDataParameter();
            createSelectionViewModel.Departments = await _departmentRepository.GetAllDataDepartment();
            createSelectionViewModel.Selections = await _selectionRepository.GetAllDataSelection();
            createSelectionViewModel.CurrentSelectionId = selectionID;
            createSelectionViewModel.CurrentSelectionName = selectionName;
            createSelectionViewModel.CurrentDepartmentID = chosenDepartmentId;
            return (createSelectionViewModel);
        }

        public async Task<ShowAllSlectionsByCurrentDepartmentViewModel> ShowAllSelections(int ID)
        {
            ShowAllSlectionsByCurrentDepartmentViewModel showAllSlectionsByCurrentDepartment = new ShowAllSlectionsByCurrentDepartmentViewModel();
            showAllSlectionsByCurrentDepartment.Selections = await _selectionRepository.GetAllDataSelection();
            showAllSlectionsByCurrentDepartment.Parameters = await _parameterRepository.GetAllDataParameter();
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            showAllSlectionsByCurrentDepartment.currentDepartmentId = user.DepartmentId;
            Department department = await _departmentRepository.GetDepartmentById(user.DepartmentId);
            showAllSlectionsByCurrentDepartment.currentDepartmentName = department.DepartmentName;
            return (showAllSlectionsByCurrentDepartment);
        }

        public async Task<ShowAllSlectionsByCurrentDepartmentViewModel> ShowAllSelections()
        {
            ShowAllSlectionsByCurrentDepartmentViewModel showAllSlectionsByCurrentDepartment = new ShowAllSlectionsByCurrentDepartmentViewModel();
            showAllSlectionsByCurrentDepartment.Selections = await _selectionRepository.GetAllDataSelection();
            showAllSlectionsByCurrentDepartment.Parameters = await _parameterRepository.GetAllDataParameter();
            User user = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            showAllSlectionsByCurrentDepartment.currentDepartmentId = user.DepartmentId;
            Department department = await _departmentRepository.GetDepartmentById(user.DepartmentId);
            showAllSlectionsByCurrentDepartment.currentDepartmentName = department.DepartmentName;
            return (showAllSlectionsByCurrentDepartment);
        }

        public async Task<GetTopBySelectSelectionViewModel> GetTopBySelectSelection(int selectionID)
        {
            User chief = await _userRepository.GetUserById(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            List<User> users = await _userRepository.GetUsersByDepartmentIdNotChief(chief.DepartmentId);

            Selection selection = await _selectionRepository.GetSelectionById(selectionID);


            var parameters = selection.Parameters.ToDictionary(p => p.ID, p => p);

            var markedUsers = new List<(User user, double mark)>(users.Count);

            foreach (var user in users)
            {
                var total = 0.0;
                var marks = new Dictionary<int, List<double>>();

                foreach (var mark in user.Marks)
                {
                    if (selection.Parameters.Contains(mark.Parameter))
                    {
                        if (!marks.ContainsKey(mark.ParameterId))
                            marks[mark.ParameterId] = new List<double>();

                        marks[mark.ParameterId].Add(mark.MarkValue);
                    }
                }

                foreach (var kv in marks)
                {
                    var average = kv.Value.Average();
                    total += average * parameters[kv.Key].Coefficient;
                }

                markedUsers.Add((user, total));
            }

            var bottomUsers = markedUsers.OrderBy(u => u.mark).Take(3).Select(t => t.user);
            var topUsers = markedUsers.OrderByDescending(u => u.mark).Take(3).Select(t => t.user);

            GetTopBySelectSelectionViewModel getTopBySelectSelection = new GetTopBySelectSelectionViewModel();
            getTopBySelectSelection.UserTop = topUsers;
            getTopBySelectSelection.UserBottom = bottomUsers;
            getTopBySelectSelection.getCurrentSelectionId = selectionID;
            getTopBySelectSelection.getCurrentSelectionName = selection.SelectionName;
            return (getTopBySelectSelection);
        }       
    }
}


