public static class Jogador
{

    public static int Vida { get; set; }


    public static bool EstaVivo()
    {
        if (Vida > 0)
        {
            return true;
        }

        return false;
    }
}