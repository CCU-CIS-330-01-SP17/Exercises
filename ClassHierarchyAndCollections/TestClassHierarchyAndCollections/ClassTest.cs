using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace TestClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the test for the <see cref="ClassHierarchyAndCollections"/> class.
    /// </summary>
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void Contact_Is_Contact()
        {
            Contact bob = new Contact("Bob", "123 Somewhere Lane", "123-456-7890");
            Assert.IsInstanceOfType(bob, typeof(Contact));
        }
        public void Organization_Is_Organization()
        {
            Organization waterBottle = new Organization("Water Bottle International", "500 Moon Lane", "000-000-0000",
                "4/4/1999", "Business");
            Assert.IsInstanceOfType(waterBottle, typeof(Organization));
        }
        public void Organziation_Is_Contact()
        {
            Organization waterBottle = new Organization("Water Bottle International", "500 Moon Lane", "000-000-0000",
                "4/4/1999", "Business");
            Assert.IsInstanceOfType(waterBottle, typeof(Contact));
        }
        public void Individual_Is_Individual()
        {
            Individual sally = new Individual("Sally", "Joe", "1234 Confused Way", "444-444-4444", "Hypnotherapist",
                "sally@therapy.com");
            Assert.IsInstanceOfType(sally, typeof(Individual));
        }
        public void Individual_Is_Contact()
        {
            Individual sally = new Individual("Sally", "Joe", "1234 Confused Way", "444-444-4444", "Hypnotherapist",
                "sally@therapy.com");
            Assert.IsInstanceOfType(sally, typeof(Contact));
        }
        public void Business_Is_Business()
        {
            Business flavorsOfTheWest = new Business("Flavors of the West", "100 Flavor Drive", "111-222-3333",
                    "2/5/05", "Business", "Vertical", "Generosity");
            Assert.IsInstanceOfType(flavorsOfTheWest, typeof(Business));
        }
        public void Business_Is_Organization()
        {
            Business flavorsOfTheWest = new Business("Flavors of the West", "100 Flavor Drive", "111-222-3333",
                "2/5/05", "Business", "Vertical", "Generosity");
            Assert.IsInstanceOfType(flavorsOfTheWest, typeof(Organization));
        }
        public void Business_Is_Contact()
        {
            Business flavorsOfTheWest = new Business("Flavors of the West", "100 Flavor Drive", "111-222-3333",
                "2 / 5 / 05", "Business", "Vertical", "Generosity");
            Assert.IsInstanceOfType(flavorsOfTheWest, typeof(Contact));
        }
        public void Association_Is_Association()
        {
            Association diabetesAssociation = new Association("Diabetes Association", "123 Diabetic Lane", "111-111-1111",
                "1/1/1991", "Association", "A1C Test", 20.00m);
            Assert.IsInstanceOfType(diabetesAssociation, typeof(Association));
        }
        public void Association_Is_Organization()
        {
            Association diabetesAssociation = new Association("Diabetes Association", "123 Diabetic Lane", "111-111-1111",
                "1/1/1991", "Association", "A1C Test", 20.00m);
            Assert.IsInstanceOfType(diabetesAssociation, typeof(Organization));
        }
        public void Association_Is_Contact()
        {
            Association diabetesAssociation = new Association("Diabetes Association", "123 Diabetic Lane", "111-111-1111",
                "1/1/1991", "Association", "A1C Test", 20.00m);
            Assert.IsInstanceOfType(diabetesAssociation, typeof(Contact));
        }
        public void School_Is_School()
        {
            School wheatonAcademy = new School("Wheaton Academy", "900 Prince Crossing Rd.", " (630) 562-7500", "1853", "School",
                "Warriors", "Maroon and White");
            Assert.IsInstanceOfType(wheatonAcademy, typeof(School));
        }
        public void School_Is_Organziation()
        {
            School wheatonAcademy = new School("Wheaton Academy", "900 Prince Crossing Rd.", " (630) 562-7500", "1853", "School",
                "Warriors", "Maroon and White");
            Assert.IsInstanceOfType(wheatonAcademy, typeof(Organization));
        }
        public void School_Is_Contact()
        {
            School wheatonAcademy = new School("Wheaton Academy", "900 Prince Crossing Rd.", " (630) 562-7500", "1853", "School",
                "Warriors", "Maroon and White");
            Assert.IsInstanceOfType(wheatonAcademy, typeof(Contact));
        }
        public void Student_Is_Student()
        {
            Student sue = new Student("Sue", "Smith", "0987 Student Lane", "222-222-2222", "Student", "sue@student.com",
                12334, "Wheaton Academy");
            Assert.IsInstanceOfType(sue, typeof(Student));
        }
        public void Student_Is_Individual()
        {
            Student sue = new Student("Sue", "Smith", "0987 Student Lane", "222-222-2222", "Student", "sue@student.com",
                12334, "Wheaton Academy");
            Assert.IsInstanceOfType(sue, typeof(Individual));
        }
        public void Student_Is_Contact()
        {
            Student sue = new Student("Sue", "Smith", "0987 Student Lane", "222-222-2222", "Student", "sue@student.com",
                12334, "Wheaton Academy");
            Assert.IsInstanceOfType(sue, typeof(Contact));
        }
        public void Member_Is_Member()
        {
            Member joe = new Member("Joe", "Smith", "7654 Smith Lane", "333-333-3333", "Lawyer", "joe@lawyer.com",
                "Malinda", "1/1/15");
            Assert.IsInstanceOfType(joe, typeof(Member));
        }
        public void Member_Is_Individual()
        {
            Member joe = new Member("Joe", "Smith", "7654 Smith Lane", "333-333-3333", "Lawyer", "joe@lawyer.com",
               "Malinda", "1/1/15");
            Assert.IsInstanceOfType(joe, typeof(Individual));
        }
        public void Member_Is_Contact()
        {
            Member joe = new Member("Joe", "Smith", "7654 Smith Lane", "333-333-3333", "Lawyer", "joe@lawyer.com",
               "Malinda", "1/1/15");
            Assert.IsInstanceOfType(joe, typeof(Contact));
        }
        public void Client_Is_Client()
        {
            Client bill = new Client("Bill", "Dude", "5280 Dude Lane", "999-999-9999", "Snowborder", "bording@life.com", "Bording Corp.", 
                "B3735LM800");
            Assert.IsInstanceOfType(bill, typeof(Client));
        }
        public void Client_Is_Individual()
        {
            Client bill = new Client("Bill", "Dude", "5280 Dude Lane", "999-999-9999", "Snowborder", "bording@life.com", "Bording Corp.",
                "B3735LM800");
            Assert.IsInstanceOfType(bill, typeof(Individual));
        }
        public void Client_Is_Contact()
        {
            Client bill = new Client("Bill", "Dude", "5280 Dude Lane", "999-999-9999", "Snowborder", "bording@life.com", "Bording Corp.",
                "B3735LM800");
            Assert.IsInstanceOfType(bill, typeof(Contact));
        }
    }
}
