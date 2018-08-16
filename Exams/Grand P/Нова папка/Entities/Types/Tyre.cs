using System;

public abstract class Tyre
{
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public virtual string Name { get; protected set; }

    public double Hardness { get; protected set; }

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }

}

