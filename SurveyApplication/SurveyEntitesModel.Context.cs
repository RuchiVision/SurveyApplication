﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SurveyApplication
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProductDBEntities : DbContext
    {
        public ProductDBEntities()
            : base("name=ProductDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblQuestion> TblQuestions { get; set; }
        public virtual DbSet<TblSurvey> TblSurveys { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserAnswer> TblUserAnswers { get; set; }
    
        public virtual int CreateQuestionProcedure(Nullable<int> surveyId, string question, string controlType, string controlOptions, string createdBy, Nullable<System.DateTime> createdON)
        {
            var surveyIdParameter = surveyId.HasValue ?
                new ObjectParameter("SurveyId", surveyId) :
                new ObjectParameter("SurveyId", typeof(int));
    
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var controlTypeParameter = controlType != null ?
                new ObjectParameter("ControlType", controlType) :
                new ObjectParameter("ControlType", typeof(string));
    
            var controlOptionsParameter = controlOptions != null ?
                new ObjectParameter("ControlOptions", controlOptions) :
                new ObjectParameter("ControlOptions", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdONParameter = createdON.HasValue ?
                new ObjectParameter("CreatedON", createdON) :
                new ObjectParameter("CreatedON", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateQuestionProcedure", surveyIdParameter, questionParameter, controlTypeParameter, controlOptionsParameter, createdByParameter, createdONParameter);
        }
    
        public virtual int CreateSurveyProcedure(string title, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, string createdBy, Nullable<System.DateTime> createdON)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdONParameter = createdON.HasValue ?
                new ObjectParameter("CreatedON", createdON) :
                new ObjectParameter("CreatedON", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateSurveyProcedure", titleParameter, fromDateParameter, toDateParameter, createdByParameter, createdONParameter);
        }
    
        public virtual int DeleteQuestionProcedure(Nullable<int> queId)
        {
            var queIdParameter = queId.HasValue ?
                new ObjectParameter("QueId", queId) :
                new ObjectParameter("QueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteQuestionProcedure", queIdParameter);
        }
    
        public virtual int DeleteSurvey(Nullable<int> surveyId)
        {
            var surveyIdParameter = surveyId.HasValue ?
                new ObjectParameter("SurveyId", surveyId) :
                new ObjectParameter("SurveyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteSurvey", surveyIdParameter);
        }
    
        public virtual int DeleteUser(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUser", userIdParameter);
        }
    
        public virtual int InsertUser(string firstName, string middleName, string lastName, string address, string city, Nullable<System.DateTime> dateofBirth, Nullable<bool> isSurveyor)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("MiddleName", middleName) :
                new ObjectParameter("MiddleName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var dateofBirthParameter = dateofBirth.HasValue ?
                new ObjectParameter("DateofBirth", dateofBirth) :
                new ObjectParameter("DateofBirth", typeof(System.DateTime));
    
            var isSurveyorParameter = isSurveyor.HasValue ?
                new ObjectParameter("IsSurveyor", isSurveyor) :
                new ObjectParameter("IsSurveyor", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUser", firstNameParameter, middleNameParameter, lastNameParameter, addressParameter, cityParameter, dateofBirthParameter, isSurveyorParameter);
        }
    
        public virtual ObjectResult<SelectAddQuestionProcedure_Result> SelectAddQuestionProcedure()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectAddQuestionProcedure_Result>("SelectAddQuestionProcedure");
        }
    
        public virtual ObjectResult<SelectAllSurvey_Result> SelectAllSurvey()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectAllSurvey_Result>("SelectAllSurvey");
        }
    
        public virtual ObjectResult<SelectAllUser_Result> SelectAllUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectAllUser_Result>("SelectAllUser");
        }
    
        public virtual int UpdateQuestion(Nullable<int> queId, Nullable<int> surveyId, string question, string controlType, string controlOptions, string createdBy, Nullable<System.DateTime> createdON)
        {
            var queIdParameter = queId.HasValue ?
                new ObjectParameter("QueId", queId) :
                new ObjectParameter("QueId", typeof(int));
    
            var surveyIdParameter = surveyId.HasValue ?
                new ObjectParameter("SurveyId", surveyId) :
                new ObjectParameter("SurveyId", typeof(int));
    
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var controlTypeParameter = controlType != null ?
                new ObjectParameter("ControlType", controlType) :
                new ObjectParameter("ControlType", typeof(string));
    
            var controlOptionsParameter = controlOptions != null ?
                new ObjectParameter("ControlOptions", controlOptions) :
                new ObjectParameter("ControlOptions", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdONParameter = createdON.HasValue ?
                new ObjectParameter("CreatedON", createdON) :
                new ObjectParameter("CreatedON", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateQuestion", queIdParameter, surveyIdParameter, questionParameter, controlTypeParameter, controlOptionsParameter, createdByParameter, createdONParameter);
        }
    
        public virtual int UpdateSurvey(Nullable<int> surveyId, string title, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, string createdBy, Nullable<System.DateTime> createdON)
        {
            var surveyIdParameter = surveyId.HasValue ?
                new ObjectParameter("SurveyId", surveyId) :
                new ObjectParameter("SurveyId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdONParameter = createdON.HasValue ?
                new ObjectParameter("CreatedON", createdON) :
                new ObjectParameter("CreatedON", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateSurvey", surveyIdParameter, titleParameter, fromDateParameter, toDateParameter, createdByParameter, createdONParameter);
        }
    
        public virtual int UpdateUser(Nullable<int> userId, string firstName, string middleName, string lastName, string address, string city, Nullable<System.DateTime> dateofBirth, Nullable<bool> isSurveyor)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("MiddleName", middleName) :
                new ObjectParameter("MiddleName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var dateofBirthParameter = dateofBirth.HasValue ?
                new ObjectParameter("DateofBirth", dateofBirth) :
                new ObjectParameter("DateofBirth", typeof(System.DateTime));
    
            var isSurveyorParameter = isSurveyor.HasValue ?
                new ObjectParameter("IsSurveyor", isSurveyor) :
                new ObjectParameter("IsSurveyor", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUser", userIdParameter, firstNameParameter, middleNameParameter, lastNameParameter, addressParameter, cityParameter, dateofBirthParameter, isSurveyorParameter);
        }
    }
}
