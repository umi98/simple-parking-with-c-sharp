class App {
    Dictionary<string, Vehicle> parking = new Dictionary<string, Vehicle>();
    
    public void play() {
        int menu = 0;
        Console.WriteLine("PARKING");
        Console.Write("Enter number of slot first: ");
        int size = int.Parse(Console.ReadLine());
        createParking(size);

        while (menu != 10) {
            menuList();
            Console.Write("Your choice: ");
            menu = int.Parse(Console.ReadLine());
            chooseMenu(menu);
        }
    }

    public void menuList() {
        Console.WriteLine("MENU");
        Console.WriteLine("1. Allocate Parking");
        Console.WriteLine("2. Leave Parking");
        Console.WriteLine("3. Status");
        Console.WriteLine("4. Number of motor");
        Console.WriteLine("5. Number of car");
        Console.WriteLine("6. Vehicle with even registration number");
        Console.WriteLine("7. Vehicle with odd registration number");
        Console.WriteLine("8. Vehicle with certain colour");
        Console.WriteLine("9. Check location with registration number");
        Console.WriteLine("10. Exit");
    }

    public void chooseMenu(int choice) {
        switch (choice) {
            case 1:
                initVehicle();
                break;
            case 2:
                leave();
                break;
            case 3:
                status();
                break;
            case 4:
                countTypeOfVehicle("motor");
                break;
            case 5:
                countTypeOfVehicle("mobil");
                break;
            case 6:
                registerNumberEven();
                break;
            case 7:
                registerNumberOdd();
                break;
            case 8:
                vehicleColour();
                break;
            case 9:
                findByRegistrationNumber();
                break;
            case 10:
                Console.WriteLine("Exiting program ...");
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }

    public void createParking(int size) {
        for (int i = 0; i < size; i++) {
            parking.Add(i.ToString(), new Vehicle());
        }
        Console.WriteLine($"Allocating {size} parking slots");
    }

    public void initVehicle() {
        int num = 0;
        foreach (var vehicle in parking.Values) {
            if (string.IsNullOrEmpty(vehicle.registrationNumber)) {
                Console.Write("Registration number: ");
                string registrationNum = Console.ReadLine();
                Console.Write("Type of vehicle: ");
                string type = Console.ReadLine();
                Console.Write("Vehicle colour: ");
                string colour = Console.ReadLine();

                Vehicle addOne = new Vehicle(registrationNum, type, colour);
                parking[num.ToString()] = addOne;
                Console.WriteLine($"Allocated to slot no. {num + 1}");
                break;
            }
            num++;
        }

        if (num >= parking.Count) Console.WriteLine("Parking full");
    }

    public void status() {
        int num = 1;
        foreach (var vehicle in parking.Values) {
            Console.WriteLine(num++);
            Console.WriteLine(vehicle.registrationNumber);
            Console.WriteLine(vehicle.type);
            Console.WriteLine(vehicle.colour);
            Console.WriteLine(new string('-', 100));
        }
    }

    public void leave() {
        Console.Write("Enter emptied slot: ");
        int slot = int.Parse(Console.ReadLine()) - 1;
        parking[slot.ToString()] = new Vehicle();
    }

    public void countTypeOfVehicle(string type) {
        int count = 0;
        foreach (var vehicle in parking.Values) {
            if (vehicle.type.Equals(type.ToLower())) {
                count++;
            }
        }
        Console.WriteLine($"Number of {type}: {count}");
    }

    public void registerNumberOdd() {
        List<string> numberList = new List<string>();
        foreach (var vehicle in parking.Values) {
            int getNumber = int.Parse(System.Text.RegularExpressions.Regex.Replace(vehicle.registrationNumber, "[^0-9]",""));
            if (getNumber%2 != 0) {
                numberList.Add(vehicle.registrationNumber);
            }
        }
        if (numberList.Count > 0) numberList.ForEach(Console.WriteLine);
        else Console.WriteLine("Not exist");
    }

    public void registerNumberEven() {
        List<string> numberList = new List<string>();
        foreach (var vehicle in parking.Values) {
            int getNumber = int.Parse(System.Text.RegularExpressions.Regex.Replace(vehicle.registrationNumber, "[^0-9]",""));
            if (getNumber%2 == 0) {
                numberList.Add(vehicle.registrationNumber);
            }
        }
        if (numberList.Count > 0) numberList.ForEach(Console.WriteLine);
        else Console.WriteLine("Not exist");
    }

    public void vehicleColour() {
        Console.Write("Enter colour: ");
        string colour = Console.ReadLine();
        List<int> numberList = new List<int>();
        int num = 0;
        foreach (var vehicle in parking.Values) {
            if (vehicle.colour.Equals(colour.ToLower())) {
                numberList.Add(num+1);
            }
            num++;
        }
        Console.WriteLine($"Vehicle with {colour} colour: {string.Join(", ", numberList)}");
    }

    public void findByRegistrationNumber() {
        Console.Write("Enter registration number: ");
        string vehicleNum = Console.ReadLine();
        int num = 0;
        foreach (var vehicle in parking.Values) {
            if (vehicle.registrationNumber == vehicleNum) {
                num += 1;
                break;
            }
            num++;
        }
        Console.WriteLine(num != 0 ? num.ToString() : "Not Found");
    }
}