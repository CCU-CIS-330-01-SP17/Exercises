using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;

namespace Week9SerializationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Binary_Serialize_Deserialize_Compare_Test()
        {
            VehicleList<Vehicle> list = new VehicleList<Vehicle>();
            list.Add(new Car("Camry") { TypeOfMotor = "V6", FuelType = "Gasoline", NumberOfWheels = 4 });
            list.Add(new Motorcycle("Harley") { TypeOfMotor = "150CC", FuelType = "Gasoline", NumberOfWheels = 2 });
            list.Add(new AirPlane("Boeing 787" { TypeOfMotor = "GEnx-1BTrent 1000", FuelType = "Jet Fuel", NumberOfWheels = 10 });

            BinaryFormat.SerializeList(list);
            var bSerial = BinaryFormat.DeserializeList();

            bool compareObjects = BinaryFormat.CompareObjects(list, bSerial);

            Assert.IsTrue(compareObjects);
        }

        [TestMethod]
        public void DataContract_Serialize_Deserialize_Compare_Test()
        {
            VehicleList<Vehicle> list = new VehicleList<Vehicle>();
            list.Add(new Car("Camry") { TypeOfMotor = "V6", FuelType = "Gasoline", NumberOfWheels = 4 });
            list.Add(new Motorcycle("Harley") { TypeOfMotor = "150CC", FuelType = "Gasoline", NumberOfWheels = 2 });
            list.Add(new AirPlane("Boeing 787" { TypeOfMotor = "GEnx-1BTrent 1000", FuelType = "Jet Fuel", NumberOfWheels = 10 });

            DataContractSerialize.SerializeList(list);
            var dSerial = DataContractSerialize.DeserializeList();

            bool compareObjects = DataContractSerialize.CompareObjects(list, dSerial);

            Assert.IsTrue(compareObjects);
        }
        [TestMethod]
        public void Json_Serialize_Deserialize_Compare_Test()
        {
            VehicleList<Vehicle> list = new VehicleList<Vehicle>();
            list.Add(new Car("Camry") { TypeOfMotor = "V6", FuelType = "Gasoline", NumberOfWheels = 4 });
            list.Add(new Motorcycle("Harley") { TypeOfMotor = "150CC", FuelType = "Gasoline", NumberOfWheels = 2 });
            list.Add(new AirPlane("Boeing 787" { TypeOfMotor = "GEnx-1BTrent 1000", FuelType = "Jet Fuel", NumberOfWheels = 10 });

            JsonSerialize.SerializeList(list);
            var jSerial = JsonSerialize.DeserializeList();

            bool compareObjects = JsonSerialize.CompareObjects(list, jSerial);

            Assert.IsTrue(compareObjects);
        }
    }
}
