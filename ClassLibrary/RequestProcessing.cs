using Newtonsoft.Json;
using Reprository;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ClassLibrary
{
    public class RequestProcessing
    {
        public RequestClass RequestClass { get; set; }
        public RequestProcessing(string requestString)
        {
            RequestClass = JsonConvert.DeserializeObject<RequestClass>(requestString);
        }
        public RequestProcessing(RequestClass requestClass)
        {
            RequestClass = requestClass;   
        }
        protected bool CheckAccount(List<Account> accounts)
        {
            int counts = 0;
            foreach (Account account in accounts)
            {
                if (account.Name == RequestClass.GetAcountName)
                {
                    counts++;
                }
            }
            if (counts == 0)
            {
                MessageBox.Show("404 – NotFound");
                return true;
            }
            return false;
        }

        protected void CheckContact(GenericUnitOfWork work)
        {
            IGenericRepository<Contact> repositoryContact = work.Repository<Contact>();
            IGenericRepository<Account> repositoryAccount = work.Repository<Account>();
            List<Contact> contacts = repositoryContact.GetAll().ToList();
            int count = 0;
            foreach (Contact contact in contacts)
            {
                if (contact.Email == RequestClass.GetContactEmail)
                {
                    repositoryContact.FindById(contact.Id).FirstName = RequestClass.GetContactFirstName;
                    repositoryContact.FindById(contact.Id).LastName = RequestClass.GetContactLastName;
                    repositoryContact.FindById(contact.Id).GetAccount = repositoryAccount.GetAll().Where(x => x.Name == RequestClass.GetAcountName).FirstOrDefault();
                    repositoryContact.Update(repositoryContact.FindById(contact.Id));
                    count++;
                }
            }
            if(count == 0)
            {
                repositoryContact.Add(new Contact
                {
                    FirstName = RequestClass.GetContactFirstName,
                    LastName = RequestClass.GetContactLastName,
                    Email = RequestClass.GetContactEmail,
                    GetAccount = repositoryAccount.GetAll().Where(x => x.Name == RequestClass.GetAcountName).FirstOrDefault()
                });
            }
        }

        protected void CheckIncident(GenericUnitOfWork work)
        {
            IGenericRepository<Incident> repositoryIncident = work.Repository<Incident>();
            IGenericRepository<Account> repositoryAccount = work.Repository<Account>();
            List<Incident> incidents = repositoryIncident.GetAll().ToList();
            int count = 0;
            foreach (Incident inc in incidents)
            {
                if(inc.Description == RequestClass.GetIcendentDesc)
                {
                    repositoryAccount.GetAll().Where(x => x.Name == RequestClass.GetAcountName).FirstOrDefault().GetIncindent = repositoryIncident.FindById(inc.Id);
                    repositoryAccount.Update(repositoryAccount.GetAll().Where(x => x.Name == RequestClass.GetAcountName).FirstOrDefault());
                    repositoryIncident.FindById(inc.Id).Description = RequestClass.GetIcendentDesc;
                    repositoryIncident.Update(repositoryIncident.FindById(inc.Id));
                    count++;
                }
            }
            if(count == 0)
            {
                repositoryIncident.Add(new Incident
                {
                    Description = RequestClass.GetIcendentDesc
                });
                repositoryAccount.GetAll().Where(x => x.Name == RequestClass.GetAcountName).FirstOrDefault().GetIncindent = repositoryIncident.GetAll().Where(x => x.Description == RequestClass.GetIcendentDesc).FirstOrDefault();
            }
        }

        public void Request()
        {
            GenericUnitOfWork work = new GenericUnitOfWork(new Account_Context("conStr"));
            IGenericRepository<Account> repositoryAccount = work.Repository<Account>();
            if (CheckAccount(repositoryAccount.GetAll().ToList())) { return; }
            CheckContact(work);
            CheckIncident(work);
        }

    }
}