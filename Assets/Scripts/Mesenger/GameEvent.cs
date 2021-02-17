using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent
{
    public const string Knifes_Quantity = "KNIFES_QUANTITY";//общее количество ножей, которые нужно бросить
    public const string Type_Of_Wood = "TIPE_OF_WOOD";//тип дерева(будет передаваться int)
    public const string Knifes_And_Apples_In_Wood = "KNIFES_ANDAPPLES_IN_WOOD";//количество ножей и яблок, которые находятся на дереве
    public const string Knifes_Throw = "KNIFES_THROW";//нож брошен(для изменения цвета в UI)
    public const string Knife_Dont_Match = "KNIFE_DONT_MATCH";//нож не попал(столкновение с другим ножем, поражние) 
    public const string Knife_Dont_Match_Sound = "KNIFE_DONT_MATCH_SOUND";//нож не попал(звук)   
    public const string Knife_In_Apple = "KNIFE_IN_APPLE";//попадание в яблоко
    public const string Apple_Score = "APPLE_SCORE";//передает на UI количество яблок
    public const string Knife_Hit = "KNIFE_HIT";//попадание в бревно
    public const string Level = "LEVEL";//уровень текущей игры
    public const string Level_Win = "LEVEL_WIN";//уровень пройден
    public const string Delete_Wood_Childs = "DELETE_WOOD_CHILDS";//удаление всех дочерних убъектов у дерева(перед переходом на следующий уровень
    public const string Next_Level = "NEXT_LEVEL";//переход на следующий уровень
    public const string Change_Score = "CHANGE_SCORE";//передает на UI количество очков
    public const string Restart = "RESTART";//перезапуск игры
    public const string Difficult = "DIFFICULT";//сложность игры(разное вращение бревна
    public const string Apple_Start = "APPLE_START";//переход к начальным настройка яблока
}
