/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to
/// the back of the queue (per FIFO rules). When GetNextPerson is called, the next
/// person in the queue is returned and then placed at the back again unless they
/// have run out of turns. A turns value of 0 or less means infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left. A turns value of 0 or less means the 
    /// person has an infinite number of turns. An InvalidOperationException is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns: do not decrement, re-enqueue
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Finite turns: decrement and re-enqueue if still has turns left
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // else if Turns == 1 → last turn, do not re-enqueue

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
