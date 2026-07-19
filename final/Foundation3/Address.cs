using System;

// Represents a mailing address. Used by every Event so the address
// details are not duplicated inside each event class.
public class Address
{
    // Member variables use _camelCase per the class naming convention.
    private string _street;
    private string _city;
    private string _state;
    private string _zipCode;

    // Constructor parameters use camelCase.
    public Address(string street, string city, string state, string zipCode)
    {
        _street = street;
        _city = city;
        _state = state;
        _zipCode = zipCode;
    }

    // No properties are used in this class, per assignment rules.
    // Plain Get/Set methods are used instead to keep the fields private.
    public string GetStreet()
    {
        return _street;
    }

    public void SetStreet(string street)
    {
        _street = street;
    }

    public string GetCity()
    {
        return _city;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    public string GetState()
    {
        return _state;
    }

    public void SetState(string state)
    {
        _state = state;
    }

    public string GetZipCode()
    {
        return _zipCode;
    }

    public void SetZipCode(string zipCode)
    {
        _zipCode = zipCode;
    }

    // Overridden normally (not as an expression-bodied member) so the
    // Address can be printed as a single formatted string.
    public override string ToString()
    {
        string result = _street + ", " + _city + ", " + _state + " " + _zipCode;
        return result;
    }
}
