# TestFriday

generic repository

public ResultClass<PersonViewModel> New()
        {
            ResultClass<PersonViewModel> RC = new ResultClass<PersonViewModel>();
            ApplicationDbContext applicationDbContext = new ApplicationDbContext(null);

            IPersonRepository personRepository = new PersonRepository(applicationDbContext);

            RC.Result.Person_ID = Guid.NewGuid();
            RC.Result.Person_isActive = true;
            RC.Result.Person_MeliNo = "1234567891";
            RC.Result.Person_ShNo= "1234567891";
            RC.Result.Person_Mobile = " 09120000000";
            

            RC.Result.Person_No = personRepository.GetNewNo();

            return RC;
        }


        public ResultClass<bool> StoreData()
        {
            
            ResultClass<bool> RC = new ResultClass<bool>();

           ApplicationDbContext applicationDbContext = new ApplicationDbContext(null);

            IPersonRepository personRepository = new PersonRepository(applicationDbContext);
            var person = personRepository.Find(this.Person_ID);
            if (person == null)
            {
                person = new Person_tbl();
                person.Person_ID = this.Person_ID;
                person.Person_No = personRepository.GetNewNo();

                personRepository.Add(person);
                

            }
            else
            {
                personRepository.Update(person);
            }


            person.Person_Name = this.Person_Name;
            person.Person_Family = this.Person_Family;
            person.Person_Address = this.Person_Address;
            person.Person_BirthDay = this.Person_BirthDay;
            person.Person_FatherName = this.Person_FatherName;
            person.Person_isJaigozin = this.Person_isJaigozin;
            person.Person_HoghoghFix = this.Person_HoghoghFix;
            person.Person_No = this.Person_No;
            person.Person_Mobile = this.Person_Mobile;
            person.Person_HesabInfo = this.Person_HesabInfo;


            applicationDbContext.SaveChanges();

            return RC;
        }


        public ResultClass<PersonViewModel> LoadData(Guid id)
        {
            ResultClass<PersonViewModel> RC = new ResultClass<PersonViewModel>();
            ApplicationDbContext applicationDbContext = new ApplicationDbContext(null);

            IPersonRepository personRepository = new PersonRepository(applicationDbContext);
            var person = personRepository.Find(id);
            this.Person_FatherName= person.Person_FatherName;
            this.Person_Name= person.Person_Name;
            this.Person_Family= person.Person_Family;
            this.Person_Address= person.Person_Address;
            this.Person_HoghoghFix=person.Person_HoghoghFix;
            this.Person_HesabInfo= person.Person_HesabInfo;
            this.Person_DrNezam= person.Person_DrNezam;
            this.Person_Info = person.Person_Info;  
            this.Person_No = person.Person_No;
            this.Person_ShNo = person.Person_ShNo;  


            return RC;
        }

        public ResultClass<bool> Delete(Guid id)
        {
            ResultClass<bool> RC = new ResultClass<bool>();
            ApplicationDbContext applicationDbContext = new ApplicationDbContext(null);

            IPersonRepository personRepository = new PersonRepository(applicationDbContext);
            var person = personRepository.Find(id);
            if (person != null)
            {
                personRepository.Remove(id);
            }
            applicationDbContext.SaveChanges(); 

            return RC;
        }

        public interface IRepository<TEntity, in TKey>
        where TEntity : class
        where TKey : struct
    {
        void Add(TEntity entity);
        void AddRange(IList<TEntity> entites);
        TEntity Find(TKey id);
        IQueryable<TEntity> GetAll();
        void Remove(TEntity entity);

        void Remove(TKey id);

        void Update(TEntity entity);


    }

