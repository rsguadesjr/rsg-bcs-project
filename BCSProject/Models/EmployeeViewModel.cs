using AutoMapper;
using BCSProject.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BCSProject.Models
{
    public class EmployeeViewModel
    {
        public int? Id { get; set; }

        public string EmployeeNo { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Required]        
        [Display(Name = "Age")]
        public byte Age { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Civil Status")]
        public string CivilStatus { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNo { get; set; }

        public List<Hobby> Hobbies { get; set; }

        [Display(Name = "Hobbies or Interests")]
        public string Hobby { get; set; }

        [Required]
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; }


        [Display(Name = "Date Resigned")]
        public DateTime? DateResigned { get; set; }

        public Employee ParseToDataModel(EmployeeViewModel viewModel)
        {
            if (viewModel.Hobby != null)
            {
                var hobbies = viewModel.Hobby.Split(',');
                var listOfHobbies = new List<Hobby>();
                foreach (var hobby in hobbies)
                {
                    listOfHobbies.Add(new Hobby { HobbyName = hobby });
                }
                viewModel.Hobbies = listOfHobbies;
            }
            return Mapper.Map<EmployeeViewModel, Employee>(viewModel);
        }

        public EmployeeViewModel ParseToViewModel(Employee dataModel)
        {
            string hobbies = "";
            if(dataModel.Hobbies != null)
            {
                string[] listOfHobbies = new string[dataModel.Hobbies.Count];
                for(int i = 0; i < dataModel.Hobbies.Count; i++)
                {
                    listOfHobbies[i] = dataModel.Hobbies[i].HobbyName;
                }
                hobbies = String.Join(",", listOfHobbies);
            }
            var viewModel =  Mapper.Map<Employee, EmployeeViewModel>(dataModel);
            viewModel.Hobby = hobbies;
            return viewModel;
        }
    }

    public class PrivacyEmployeeViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Display(Name = "Property Name")]
        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }

        [Display(Name = "Public or Private")]
        public bool IsPublic { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public List<EmployeeCharacteristic> ParseToDataModel(List<PrivacyEmployeeViewModel> viewModel)
        {
            var list = new List<EmployeeCharacteristic>();
            foreach(var model in viewModel)
            {
                list.Add(Mapper.Map<PrivacyEmployeeViewModel, EmployeeCharacteristic>(model));
            }
            return list;
        }

        public List<PrivacyEmployeeViewModel> ParseToViewModel(List<EmployeeCharacteristic> viewModel)
        {
            var list = new List<PrivacyEmployeeViewModel>();
            foreach (var model in viewModel)
            {
                list.Add(Mapper.Map<EmployeeCharacteristic, PrivacyEmployeeViewModel>(model));
            }
            return list;
        }
    }
}