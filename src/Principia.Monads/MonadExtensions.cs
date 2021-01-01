namespace Principia.Monads
{
    public static class MonadExtensions
    {
        public static Monad<T> Join<T>(Monad<Monad<T>> monad)
            => monad.Value;

        //Map: IMonad<B> Fmap<B>(Func<A, B> function); 
        //App IMonad<B> App<B>(IMonad<Func<A, B>> functionMonad); 
        //Combine
        //When
        //On
        //Handle/Visit
    }
}
