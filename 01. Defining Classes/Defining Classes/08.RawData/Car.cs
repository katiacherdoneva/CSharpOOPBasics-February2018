using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private Engine engine; //engineSpeed, enginePower
    private Cargo cargo; //cargoWeight, cargoType
    private Tires tires; //tirePressure,  tireAge

    public Car(string model, Engine engine, Cargo cargo, Tires tire)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tires = tire;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public Tires Tires
    {
        get { return tires; }
        set { tires = value; }
    }
}
