using MyDefence;

namespace Sample
{
    public class SingletonTest2 : Singleton<SingletonTest2>
    {
        #region �̱���

        //public static SingletonTest2 instance;

        //public static SingletonTest2 Instance
        //{
        //    get { return instance; }
        //}

        //private void Awake()
        //{
        //    if (instance != null)
        //    {

        //        Destroy(gameObject);
        //        return;

        //    }

        //    instance = this;
        //}
        #endregion

        public int num = 1234;
    }
}
