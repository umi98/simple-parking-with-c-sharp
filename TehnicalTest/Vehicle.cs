class Vehicle {
    public string registrationNumber {set;get;}
    public string type {set;get;}
    public string colour {set;get;}

    public Vehicle(string registrationNumber,string type,string colour) {
        this.registrationNumber = registrationNumber;
        this.type = type;
        this.colour = colour;
    }

    public Vehicle() {}

    public override string ToString()
    {
        return $"Vehicle{{registrationNum='{registrationNumber}', type='{type}', colour='{colour}'}}";
    }
}