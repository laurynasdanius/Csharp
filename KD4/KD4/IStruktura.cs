//Another way to achieve abstraction in C#, is with interfaces.
//An interface is a completely "abstract class", which can only contain abstract methods and properties(with empty bodies):

interface IStruktura
{
    
    void kurti(); // interface method (does not have a body)
    void ataskaita(string pagrindinisAplankalas, string ataskaitosAplankaloPav);
    void trinti();


}