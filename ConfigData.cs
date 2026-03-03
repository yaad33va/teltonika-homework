using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("config")]
public class Config
{
    [XmlElement("version")]
    public VersionItem Version { get; set; }

    [XmlElement("person")]
    public PersonCollection Person { get; set; }

    [XmlElement("uptime")]
    public UptimeItem Uptime { get; set; }
}

public class VersionItem
{
    [XmlAttribute("type")]
    public string Type { get; set; }

    [XmlText]
    public string Value { get; set; }
}

public class UptimeItem
{
    [XmlAttribute("type")]
    public string Type { get; set; }

    [XmlText]
    public long Value { get; set; }
}
// Laiko sąrašą atskirų account'ų. 
public class PersonCollection
{
    [XmlElement("acc")]
    public List<Account> Accounts { get; set; }
}

public class Account
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("enabled")]
    public int Enabled { get; set; }

    [XmlElement("user_name")]
    public string UserName { get; set; }

    [XmlElement("password")]
    public PasswordItem Password { get; set; }

    [XmlIgnore]
    public string PasswordText
    {
        get { return Password?.Value; }
        set { if (Password != null) Password.Value = value; }
    }

    [XmlIgnore]
    public string PasswordType
    {
        get { return Password?.Type; }
        set { if (Password != null) Password.Type = value; }
    }
}
// Saugo slaptažodžio formatą ar enabled, ar plaintext.
public class PasswordItem
{
    [XmlAttribute("type")]
    public string Type { get; set; }

    [XmlText]
    public string Value { get; set; }
}