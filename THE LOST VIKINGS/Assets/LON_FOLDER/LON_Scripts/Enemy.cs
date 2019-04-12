
using UnityEngine;


namespace EnemyClass
{
    [System.Serializable]
    public class Enemy
    {
        public int maxHp;
        public int currentHp; //{get; private set;}
        public int armor;
        public int damages;
        public float shootingRate;
        public EnemyType type;
        public GameObject projectile;

        public Enemy(int hp, int _armor, int dmgs, float sRate, EnemyType _type, GameObject _projectile = null)
        {
            maxHp = hp;
            currentHp = hp;
            armor = _armor;
            damages = dmgs;
            shootingRate = sRate;
            type = _type;
            projectile = _projectile;
        }

        public Enemy()
        {
            currentHp = 50;
            damages = 1;
            shootingRate = 2;
            type = EnemyType.melee;
        }

        /// <summary>
        /// Retire les dégats à l'ennemi.
        /// </summary>
        /// <param name="_dmg">Dégats retirés.</param>
        public void TakeDamages(int _dmg)
        {
            currentHp = Mathf.Clamp(currentHp - _dmg, 0, maxHp);
        }
    }

    public enum EnemyType {melee, distance, mixed}
}

