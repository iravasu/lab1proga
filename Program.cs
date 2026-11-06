namespace lab2
{
    public abstract class GameObject
    {
        protected int Id { get;  set; }
        protected string Name { get;  set;}
        protected int X { get; set;}
        protected int Y { get; set;}

        public int getId() => Id;
        public string getName() => Name;
        public int getX() => X;
        public int getY() => Y;

        public GameObject(int id, string name, int x, int y)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
        }
    }

    public abstract class Building : GameObject
    {
        protected bool Built { get; set; }
        public bool isBuilt() =>  Built;

        public Building(int id, string name, int x, int y, bool built) : base(id, name, x, y)
        {
            Built =  built;
        }
    }

    public abstract class Unit : GameObject
    {
        protected bool Alive { get; set; }
        protected float Hp { get; set; }
        
        public bool isAlive() => Alive;
        public float getHp() => Hp;

        public Unit(int id, string name, int x, int y, bool isAlive, float hp) : base(id, name, x, y)
        {
            Alive = isAlive;
            Hp = hp;
        }

        public void receiveDamage(float damage)
        {
            Hp -= damage;
            if (Hp <= 0) Alive = false;
        }
    }

    public class Fort : Building, IAttacker
    {
        public Fort(int id, string name, int x, int y, bool built) : base(id, name, x, y, built)
        {
        }

        public void attack(Unit unit)
        {
            unit.receiveDamage(15);
        }
    }

    public class MobileHome : Building, IMoveable
    {

        public MobileHome(int id, string name, int x, int y, bool built) : base(id, name, x, y, built)
        {
        }
    }

    public class Archer : Unit, IAttacker, IMoveable
    {
        
        public Archer (int id, string name,  int x, int y, bool isAlive, float hp) : base(id, name, x, y, isAlive, hp){}

        public void attack(Unit unit)
        {
            unit.receiveDamage(7);
        }
    }

    public interface IAttacker
    {
        void attack(Unit unit);
    }

    public interface IMoveable
    {
    }
    
    
    public class Program
    {
        
        static void Main(string[] args)
        {
        }
    }
}