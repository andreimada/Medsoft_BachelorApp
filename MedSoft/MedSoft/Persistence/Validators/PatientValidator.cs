using Model;
using Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Validators {
    public class PatientValidator : IValidator<Patient> {
        public void validate(Patient entity) {
            string error = "";
            if(entity.Username.Length == 0 || entity.Username.Length <= 20) {
                error += "Numele de utilizator nu corespunde\n";
            }
            if (entity.Password.Length == 0 || entity.Password.Length <= 20) {
                error += "Parola nu corespunde\n";
            }
            if(entity.FirstName.Length == 0 || entity.FirstName.Length <= 20) {
                error += "Prenumele nu corespunde\n";
            }
            if (entity.LastName.Length == 0 || entity.LastName.Length <= 20) {
                error += "Numele nu corespunde\n";
            }
            if (entity.Cnp.Length != 13) {
                error += "CNP nu corespunde\n";
            }
            if(entity.Address.Length == 0 || entity.Address.Length <= 20) {
                error += "Adresa nu corespunde\n";
            }
            if(entity.Phone.Length != 10) {
                error += "Numarul de telefon nu corespunde\n";
            }
            if (!error.Equals("")) {
                throw new ValidatorException(error);
            }
        }
    }
}
