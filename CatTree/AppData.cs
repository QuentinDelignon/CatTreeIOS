using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Foundation;
using Microcharts;
using Newtonsoft.Json;
using OpenTK.Graphics.ES11;
using SkiaSharp;
using UIKit;

namespace CatTree
{
    public static class AppData
    {
        public static class Inventory
        {
            public static List<StoreItem> Cats = new List<StoreItem>();
            public static List<StoreItem> Patterns = new List<StoreItem>();

            public static void SaveCats()
            {
                var json = JsonConvert.SerializeObject(Cats, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Inventory_Cats.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadCats()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Inventory_Cats.json");
                string output = File.ReadAllText(filename);
                List<StoreItem> deserializedProduct = JsonConvert.DeserializeObject<List<StoreItem>>(output);
                Cats = deserializedProduct;
            }
            public static void SavePatterns()
            {
                var json = JsonConvert.SerializeObject(Patterns, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Inventory_Patterns.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadPatterns()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Inventory_Patterns.json");
                string output = File.ReadAllText(filename);
                List<StoreItem> deserializedProduct = JsonConvert.DeserializeObject<List<StoreItem>>(output);
                Patterns = deserializedProduct;
            }
            public static void BuyItem(int type , int index)
            {
                if (type == 0)
                {
                    StoreItem NewItem = AvailableItems.Cats[index];
                    Cats.Add(NewItem);
                    AvailableItems.Cats.RemoveAt(index);
                    SaveCats();
                    AvailableItems.SaveCats();
                }
                if (type == 1)
                {
                    StoreItem NewItem = AvailableItems.Patterns[index];
                    Patterns.Add(NewItem);
                    AvailableItems.Patterns.RemoveAt(index);
                    SavePatterns();
                    AvailableItems.SavePatterns();

                }
            }
        }

        public static class AvailableItems
        {
            public static List<StoreItem> Cats = new List<StoreItem>()
            {
                new StoreItem(){cellTitle="Chatton Patient",cellDesc="Il attend des calins calinettes !",cellPrice="0",cellImagePath="cat/awaiting_kitten.png"},
                new StoreItem(){cellTitle="Chat à Lunettes",cellDesc="Qu'est ce qu'il peut bien regarder comme ça ?",cellPrice="1000",cellImagePath="cat/badass_kitten.png"},
                new StoreItem(){cellTitle="Chat Noir",cellDesc="Certains disent qu'il porte malheur mais il est si mignon !",cellPrice="1000",cellImagePath="cat/black_cat.png"},
                new StoreItem(){cellTitle="Pti Chatton",cellDesc="Ce regard ! Il est si mignon !!",cellPrice="2000",cellImagePath="cat/blue_eyed_kitten.png"},
                new StoreItem(){cellTitle="Chat Ouvrier",cellDesc="Il construit des chattières de luxe avec ses petites mimines !",cellPrice="2000",cellImagePath="cat/btp_cat.png"},
                new StoreItem(){cellTitle="Chat de Noel",cellDesc="Il chantes des chants de Noel à son maitre !",cellPrice="2000",cellImagePath="cat/christmas_kitten.png"},
                new StoreItem(){cellTitle="Chat Curieux",cellDesc="Il se demande ce que tu fais à le regarder comme ça !",cellPrice="3000",cellImagePath="cat/curious_kitten.png"},
                new StoreItem(){cellTitle="Boule de Poil",cellDesc="Il est tout Fluffy !!",cellPrice="3000",cellImagePath="cat/cute_kitten.png"},
                new StoreItem(){cellTitle="Chatton",cellDesc="On a juste envie de lui faire un gros calin !",cellPrice="3000",cellImagePath="cat/cute_kitty.png"},
                new StoreItem(){cellTitle="Chat qui DAB",cellDesc="Hit em with the DAB !",cellPrice="4000",cellImagePath="cat/dab_cat.png"},
                new StoreItem(){cellTitle="Chat Livreur",cellDesc="Le Chat qui livre ton colis !",cellPrice="4000",cellImagePath="cat/delivery_cat.png"},
                new StoreItem(){cellTitle="Chat DJ",cellDesc="Il passe les meilleurs sons avec ses papattes !",cellPrice="4000",cellImagePath="cat/dj_cat.png"},
                new StoreItem(){cellTitle="Chat Docteur !",cellDesc="Il fait des ordonnances pour des lechouilles !",cellPrice="5000",cellImagePath="cat/doc_cat.png"},
                new StoreItem(){cellTitle="Duo de Choc",cellDesc="Ils s'entendent comme chien et chats !",cellPrice="5000",cellImagePath="cat/dog_cat.png"},
                new StoreItem(){cellTitle="Chat qui Doute",cellDesc="Il te juge quand tu fais des betises ...",cellPrice="5000",cellImagePath="cat/doubt_cat.png"},
                new StoreItem(){cellTitle="Chat Dragon",cellDesc="On sera fixé sur sa nature si il commence à cracher du feu",cellPrice="6000",cellImagePath="cat/dragon_cat.png"},
                new StoreItem(){cellTitle="Aristochat",cellDesc="Le Chat des Aristochats !",cellPrice="6000",cellImagePath="cat/drawn_cat.png"},
                new StoreItem(){cellTitle="Chaton qui Roule",cellDesc="N'amasse pas mousse !",cellPrice="6000",cellImagePath="cat/drawn_white_kitten.png"},
                new StoreItem(){cellTitle="Duo de Chattons",cellDesc="2 fois plus mignon !",cellPrice="7000",cellImagePath="cat/duo_cat.png"},
                new StoreItem(){cellTitle="Chatton qui s'étire",cellDesc="Il sort de sa sieste",cellPrice="7000",cellImagePath="cat/etirement_kitten.png"},
                new StoreItem(){cellTitle="Chat Fluffy",cellDesc="Il est tout Fluffy !",cellPrice="7000",cellImagePath="cat/fluffy_cat.png"},
                new StoreItem(){cellTitle="Chat Gris",cellDesc="Un beau chat gris",cellPrice="8000",cellImagePath="cat/grey_cat.png"},
                new StoreItem(){cellTitle="Chat Souple",cellDesc="Grand écart !",cellPrice="8000",cellImagePath="cat/gym_kitten.png"},
                new StoreItem(){cellTitle="Chat Innocent",cellDesc="Haut les mains !",cellPrice="8000",cellImagePath="cat/hands_up_cat.png"},
                new StoreItem(){cellTitle="Helmutz",cellDesc="Le chat de la fameuse influenceuse !",cellPrice="9000",cellImagePath="cat/helmutz_cat.png"},
                new StoreItem(){cellTitle="Bro Chat",cellDesc="Top là !",cellPrice="9000",cellImagePath="cat/high_five_cat.png"},
                new StoreItem(){cellTitle="Chat Chasseur",cellDesc="Il a chassé les moustiques !",cellPrice="9000",cellImagePath="cat/hunting_kitten.png"},
                new StoreItem(){cellTitle="Chat Inventeur",cellDesc="On dit qu'il a percé le secret du voyage dans le temps",cellPrice="9000",cellImagePath="cat/inventor_cat.png"},
                new StoreItem(){cellTitle="Chat Japonnais",cellDesc="On dit qu'il apporte la bonne fortune !",cellPrice="10000",cellImagePath="cat/japanese_cat.png"},
                new StoreItem(){cellTitle="Chat Manga",cellDesc="Tout droit venu du pays du soleil levant !",cellPrice="10000",cellImagePath="cat/kawai_cat.png"},
                new StoreItem(){cellTitle="Chat sur le Dos",cellDesc="Il est sur le point de faire dodo ! ",cellPrice="10000",cellImagePath="cat/laying_kitten.png"},
                new StoreItem(){cellTitle="Chat Solitaire",cellDesc="Il cherche ses copains !",cellPrice="10000",cellImagePath="cat/lonely_kitten.png"},
                new StoreItem(){cellTitle="Chattons Sumos",cellDesc="Ces Sumos là ne luttent pas !",cellPrice="11000",cellImagePath="cat/manga_cat.png"},
                new StoreItem(){cellTitle="Chat Mexicain",cellDesc="Il fete le jour des morts !",cellPrice="11000",cellImagePath="cat/mexican_kitten.png"},
                new StoreItem(){cellTitle="Chat Orange",cellDesc="Une belle bete !",cellPrice="11000",cellImagePath="cat/orange_cat.png"},
                new StoreItem(){cellTitle="Chat aux Abois",cellDesc="On ne sait pas pourquoi, mais il est pret !",cellPrice="12000",cellImagePath="cat/ready_cat.png"},
                new StoreItem(){cellTitle="Chat de Noel",cellDesc="Il vient distribuer des cadeaux",cellPrice="12000",cellImagePath="cat/santa_cat.png"},
                new StoreItem(){cellTitle="Chat Influenceur",cellDesc="Il n'arrete pas de se prendre en photo",cellPrice="12000",cellImagePath="cat/selfie_cat.png"},
                new StoreItem(){cellTitle="Chat Sur",cellDesc="Chat Sur , Chaussure ...",cellPrice="13000",cellImagePath="cat/shoe_kitten.png"},
                new StoreItem(){cellTitle="Chatpping",cellDesc="C'est les soldes aujourd'hui !",cellPrice="13000",cellImagePath="cat/shopping_kitten.png"},
                new StoreItem(){cellTitle="Chat Espion",cellDesc="Eh mais c'est pas un chat lui !",cellPrice="13000",cellImagePath="cat/spy_cat.png"},
                new StoreItem(){cellTitle="Tigrou",cellDesc="GRAOUUU !!",cellPrice="14000",cellImagePath="cat/tigrou.png"},
                new StoreItem(){cellTitle="Chat Tomate",cellDesc="Il a un nom de super héros",cellPrice="14000",cellImagePath="cat/tomato_cat.png"},
                new StoreItem(){cellTitle="Chat Voyageur",cellDesc="En plein tour du monde !",cellPrice="14000",cellImagePath="cat/traveller_cat.png"},
                new StoreItem(){cellTitle="Chat Chuchoteur",cellDesc="Il veut te raconter un secret !",cellPrice="15000",cellImagePath="cat/whispering_cat.png"},
                new StoreItem(){cellTitle="Chat d'Hiver",cellDesc="Il tricote un pull pour ne pas avoir trop froid",cellPrice="15000",cellImagePath="cat/winter_cat.png"}
            };
            public static List<StoreItem> Patterns = new List<StoreItem>()
            {
                new StoreItem(){cellTitle="Foret de Bambou",cellDesc="Un décor issu des Vallées de Sa Pa",cellPrice="0",cellImagePath="pattern/bambous.png"},
                new StoreItem(){cellTitle="Barcelone",cellDesc="Tapas + Sangria + Gaudhi le mix parfait ",cellPrice="1000",cellImagePath="pattern/barcelona.png"},
                new StoreItem(){cellTitle="Plage",cellDesc="Avec un livre ou pour se baigner c'est super !",cellPrice="1000",cellImagePath="pattern/beach.jpg"},
                new StoreItem(){cellTitle="Bateau",cellDesc="Quoi de mieux qu'une bonne virée en mer ?",cellPrice="2000",cellImagePath="pattern/boat.png"},
                new StoreItem(){cellTitle="Bulles",cellDesc="Comme dans le bain !",cellPrice="2000",cellImagePath="pattern/bubbles.jpg"},
                new StoreItem(){cellTitle="Cyan",cellDesc="Un bleu bien vif !",cellPrice="2000",cellImagePath="pattern/cyan.png"},
                new StoreItem(){cellTitle="Caisse Manga",cellDesc="Parfait pour un décor de BD !",cellPrice="3000",cellImagePath="pattern/door.png"},
                new StoreItem(){cellTitle="70's",cellDesc="On pourrait trouver ce motif sur les papiers peints de l'époque",cellPrice="3000",cellImagePath="pattern/dots.png"},
                new StoreItem(){cellTitle="Foret",cellDesc="Une Foret d'arbre morte tout droit sortie de la Pologne",cellPrice="3000",cellImagePath="pattern/forest.png"},
                new StoreItem(){cellTitle="Glacier",cellDesc="Un veritable defi pour les fans d'éscalade !",cellPrice="4000",cellImagePath="pattern/ice_mountain.png"},
                new StoreItem(){cellTitle="Japon",cellDesc="Un fond faisant honneur au pays du soleil levant !",cellPrice="4000",cellImagePath="pattern/japan.png"},
                new StoreItem(){cellTitle="Londres",cellDesc="God save the Queen !",cellPrice="4000",cellImagePath="pattern/london.png"},
                new StoreItem(){cellTitle="Carte",cellDesc="Alors, On va par ou ?",cellPrice="5000",cellImagePath="pattern/map.png"},
                new StoreItem(){cellTitle="Moscow",cellDesc="Ra Ra Rasputin !",cellPrice="5000",cellImagePath="pattern/moscow.png"},
                new StoreItem(){cellTitle="Petit Train",cellDesc="En route pour l'aventure !",cellPrice="5000",cellImagePath="pattern/mountain-railway.png"},
                new StoreItem(){cellTitle="Montagne",cellDesc="On entend le bruit des cloces des vaches d'en bas !",cellPrice="6000",cellImagePath="pattern/mountain.png"},
                new StoreItem(){cellTitle="New York",cellDesc="La Grande Pomme",cellPrice="6000",cellImagePath="pattern/new_york.png"},
                new StoreItem(){cellTitle="Paris",cellDesc="La Dame de Fer",cellPrice="6000",cellImagePath="pattern/paris.jpg"},
                new StoreItem(){cellTitle="Pink Floyd",cellDesc="La face cachée de la lune !",cellPrice="7000",cellImagePath="pattern/pink_floyd.png"},
                new StoreItem(){cellTitle="Abstrait",cellDesc="Une oeuvre particulière",cellPrice="7000",cellImagePath="pattern/rectangles.png"},
                new StoreItem(){cellTitle="Rio de Janeiro",cellDesc="Tuto Buen !",cellPrice="7000",cellImagePath="pattern/rio.png"},
                new StoreItem(){cellTitle="Roma",cellDesc="Senatus Populus Que Romanus",cellPrice="8000",cellImagePath="pattern/roma.png"},
                new StoreItem(){cellTitle="Rosace",cellDesc="Magnifique !",cellPrice="8000",cellImagePath="pattern/rosace.png"},
                new StoreItem(){cellTitle="San Francisco",cellDesc="A nous la Californie !",cellPrice="8000",cellImagePath="pattern/san_francisco.png"},
                new StoreItem(){cellTitle="Espace",cellDesc="Du vide à l'Infini",cellPrice="9000",cellImagePath="pattern/space.jpg"},
                new StoreItem(){cellTitle="Plouf !",cellDesc="Y'en a partout !",cellPrice="9000",cellImagePath="pattern/splash.png"},
                new StoreItem(){cellTitle="Plouf ! un Sctroumpf",cellDesc="Gargamelle va pas etre content !",cellPrice="9000",cellImagePath="pattern/splash_blue.jpg"},
                new StoreItem(){cellTitle="Xperia",cellDesc="Autant en emporte le vent",cellPrice="10000",cellImagePath="pattern/swift.jpg"},
                new StoreItem(){cellTitle="La vague",cellDesc="C'est le moment de sortir la planche de surf !",cellPrice="10000",cellImagePath="pattern/water.jpg"},
                new StoreItem(){cellTitle="Placo",cellDesc="Un classique de la décoration d'intérieur",cellPrice="10000",cellImagePath="pattern/wood.jpg"},
                new StoreItem(){cellTitle="Bois",cellDesc="Rustique et Naturel, Attention aux echardes !",cellPrice="10000",cellImagePath="pattern/wooden.png"}
            };

            public static void SaveCats()
            {
                var json = JsonConvert.SerializeObject(Cats, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Available_Cats.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadCats()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Available_Cats.json");
                string output = File.ReadAllText(filename);
                List<StoreItem> deserializedProduct = JsonConvert.DeserializeObject<List<StoreItem>>(output);
                Cats = deserializedProduct;
            }
            public static void SavePatterns()
            {
                var json = JsonConvert.SerializeObject(Patterns, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Available_Patterns.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadPatterns()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Available_Patterns.json");
                string output = File.ReadAllText(filename);
                List<StoreItem> deserializedProduct = JsonConvert.DeserializeObject<List<StoreItem>>(output);
                Patterns = deserializedProduct;
            }
        }

        public static class TreeItems
        {
            public static List<StoreItem> Cats = new List<StoreItem>();
            public static List<StoreItem> Patterns = new List<StoreItem>();
            public static void SaveCats()
            {
                var json = JsonConvert.SerializeObject(Cats, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Tree_Cats.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadCats()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Tree_Cats.json");
                string output = File.ReadAllText(filename);
                List<StoreItem> deserializedProduct = JsonConvert.DeserializeObject<List<StoreItem>>(output);
                Cats = deserializedProduct;
            }
            public static void SavePatterns()
            {
                var json = JsonConvert.SerializeObject(Patterns, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Tree_Patterns.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadPatterns()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Tree_Patterns.json");
                string output = File.ReadAllText(filename);
                List<StoreItem> deserializedProduct = JsonConvert.DeserializeObject<List<StoreItem>>(output);
                Patterns = deserializedProduct;
            }
            public static void AddItems(StoreItem cat , StoreItem pat)
            {
                Cats.Add(cat);
                Patterns.Add(pat);
                SaveCats();
                SavePatterns();
            }
        }

        public static class AchievementItems
        {
            public static List<AchievementItem> Done = new List<AchievementItem>();
            public static List<AchievementItem> Ongoing = new List<AchievementItem>();
            public static List<AchievementItem> All = new List<AchievementItem>()
            {
                // Pièces 0 - 6
                new AchievementItem() {cellTitle="RSA",cellDesc="Gagner 100 pièces",cellImage="achievements/money/coin.png",progress=0.0f},
                new AchievementItem() {cellTitle="SMIC",cellDesc="Gagner 1 000 pièces",cellImage="achievements/money/coins.png",progress=0.0f},
                new AchievementItem() {cellTitle="Jeune Entrepreneur",cellDesc="Gagner 2 000 pièces",cellImage="achievements/money/coins2.png",progress=0.0f},
                new AchievementItem() {cellTitle="CEO",cellDesc="Gagner 5 000 pièces",cellImage="achievements/money/note.png",progress=0.0f},
                new AchievementItem() {cellTitle="Elon Musk",cellDesc="Gagner 10 000 pièces",cellImage="achievements/money/notes.png",progress=0.0f},
                new AchievementItem() {cellTitle="Bill Gates",cellDesc="Gagner 50 000 pièces",cellImage="achievements/money/bag.png",progress=0.0f},
                new AchievementItem() {cellTitle="Jeff Besos",cellDesc="Gagner 100 000 pièces",cellImage="achievements/money/bank.png",progress=0.0f},
                // Jours 7-15
                new AchievementItem() {cellTitle="Quart Temps",cellDesc="Travailler 2 Jours d'affilé",cellImage="achievements/rows/date2.png",progress=0.0f},
                new AchievementItem() {cellTitle="Mi Temps",cellDesc="Travailler 3 Jours d'affilé",cellImage="achievements/rows/date3.png",progress=0.0f},
                new AchievementItem() {cellTitle="Thank God It's Friday !",cellDesc="Travailler 5 Jours d'affilé",cellImage="achievements/rows/date5.png",progress=0.0f},
                new AchievementItem() {cellTitle="Plein Temps",cellDesc="Travailler 7 Jours d'affilé",cellImage="achievements/rows/date7.png",progress=0.0f},
                new AchievementItem() {cellTitle="Noces D'Etain",cellDesc="Travailler 10 Jours d'affilé",cellImage="achievements/rows/date10.png",progress=0.0f},
                new AchievementItem() {cellTitle="Noces de Cristal",cellDesc="Travailler 15 Jours d'affilé",cellImage="achievements/rows/date15.png",progress=0.0f},
                new AchievementItem() {cellTitle="Noces de Porcelaine",cellDesc="Travailler 20 Jours d'affilé",cellImage="achievements/rows/date20.png",progress=0.0f},
                new AchievementItem() {cellTitle="Noces de Perle",cellDesc="Travailler 30 Jours d'affilé",cellImage="achievements/rows/date30.png",progress=0.0f},
                new AchievementItem() {cellTitle="Noces de Diamant",cellDesc="Travailler 60 Jours d'affilé",cellImage="achievements/rows/date60.png",progress=0.0f},
                // Heures 16-25
                new AchievementItem() {cellTitle="Ecolier",cellDesc="Travailler 1 heure",cellImage="achievements/hours/h1.png",progress=0.0f},
                new AchievementItem() {cellTitle="Collègien",cellDesc="Travailler 2 heures",cellImage="achievements/hours/h2.png",progress=0.0f},
                new AchievementItem() {cellTitle="Lycéen",cellDesc="Travailler 5 heures",cellImage="achievements/hours/h5.png",progress=0.0f},
                new AchievementItem() {cellTitle="PACES",cellDesc="Travailler 10 heures",cellImage="achievements/hours/h10.png",progress=0.0f},
                new AchievementItem() {cellTitle="Carré",cellDesc="Travailler 20 heures",cellImage="achievements/hours/h20.png",progress=0.0f},
                new AchievementItem() {cellTitle="Externe",cellDesc="Travailler 50 heures",cellImage="achievements/hours/h50.png",progress=0.0f},
                new AchievementItem() {cellTitle="Bébé Docteur",cellDesc="Travailler 100 heures",cellImage="achievements/hours/h100.png",progress=0.0f},
                new AchievementItem() {cellTitle="Medecin du Travail / Légiste ",cellDesc="Travailler 200 heures",cellImage="achievements/hours/h200.png",progress=0.0f},
                new AchievementItem() {cellTitle="Docteur !",cellDesc="Travailler 500 heures",cellImage="achievements/hours/h500.png",progress=0.0f},
                new AchievementItem() {cellTitle="Radiologue DAMN!!",cellDesc="Travailler 1000 heures",cellImage="achievements/hours/h1000.png",progress=0.0f},
                // Chats 26-32
                new AchievementItem() {cellTitle="1 Ptit Chat ...",cellDesc="Acheter 1 Chat",cellImage="achievements/cats/cat1.png",progress=0.0f},
                new AchievementItem() {cellTitle="3 Ptit Chats ...",cellDesc="Acheter 3 Chats",cellImage="achievements/cats/cat2.png",progress=0.0f},
                new AchievementItem() {cellTitle="Mais il est trop Mignon !",cellDesc="Acheter 5 Chats",cellImage="achievements/cats/cat3.png",progress=0.0f},
                new AchievementItem() {cellTitle="Amis des Félins !",cellDesc="Acheter 10 Chats",cellImage="achievements/cats/cat4.png",progress=0.0f},
                new AchievementItem() {cellTitle="Folle aux Chats !",cellDesc="Acheter 20 Chats",cellImage="achievements/cats/cat5.png",progress=0.0f},
                new AchievementItem() {cellTitle="Animalis",cellDesc="Acheter 40 Chats",cellImage="achievements/cats/cat6.png",progress=0.0f},
                new AchievementItem() {cellTitle="30 Millions d'Amis",cellDesc="Acheter 50 Chats",cellImage="achievements/cats/cat7.png",progress=0.0f},
                // Objets 33-41
                new AchievementItem() {cellTitle="Petit Plaisir",cellDesc="Acheter 1 Objet",cellImage="achievements/shopping/shop1.png",progress=0.0f},
                new AchievementItem() {cellTitle="Aprem Shopping",cellDesc="Acheter 3 Objets",cellImage="achievements/shopping/shop3.png",progress=0.0f},
                new AchievementItem() {cellTitle="Journée Shopping",cellDesc="Acheter 5 Objets",cellImage="achievements/shopping/shop5.png",progress=0.0f},
                new AchievementItem() {cellTitle="Amazon Prime",cellDesc="Acheter 10 Objets",cellImage="achievements/shopping/shop10.png",progress=0.0f},
                new AchievementItem() {cellTitle="Au Pire y'a Vinted !",cellDesc="Acheter 20 Objets",cellImage="achievements/shopping/shop20.png",progress=0.0f},
                new AchievementItem() {cellTitle="Mais si je l'ai pas celui-là",cellDesc="Acheter 40 Objets",cellImage="achievements/shopping/shop40.png",progress=0.0f},
                new AchievementItem() {cellTitle="Magasin de Quartier",cellDesc="Acheter 50 Objets",cellImage="achievements/shopping/shop50.png",progress=0.0f},
                new AchievementItem() {cellTitle="Centre Commercial",cellDesc="Acheter 80 Objets",cellImage="achievements/shopping/shop80.png",progress=0.0f},
                new AchievementItem() {cellTitle="Hangar Amazon",cellDesc="Acheter 100 Objets",cellImage="achievements/shopping/shop100.png",progress=0.0f},
                // Fonds 42-49
                new AchievementItem() {cellTitle="Souriez !!",cellDesc="Acheter 1 Arrière-Plan",cellImage="achievements/patterns/bg1.png",progress=0.0f},
                new AchievementItem() {cellTitle="Boomer Sur Instagram",cellDesc="Acheter 3 Arrière-Plans",cellImage="achievements/patterns/bg3.png",progress=0.0f},
                new AchievementItem() {cellTitle="Attends je mets un filtre !",cellDesc="Acheter 5 Arrière-Plans",cellImage="achievements/patterns/bg5.png",progress=0.0f},
                new AchievementItem() {cellTitle="J'ai plein de Followers !",cellDesc="Acheter 10 Arrière-Plans",cellImage="achievements/patterns/bg10.png",progress=0.0f},
                new AchievementItem() {cellTitle="Stella Pearl",cellDesc="Acheter 20 Arrière-Plans",cellImage="achievements/patterns/bg20.png",progress=0.0f},
                new AchievementItem() {cellTitle="Placement de Produit",cellDesc="Acheter 40 Arrière-Plans",cellImage="achievements/patterns/bg40.png",progress=0.0f},
                new AchievementItem() {cellTitle="Influenceuse",cellDesc="Acheter 50 Arrière-Plans",cellImage="achievements/patterns/bg50.png",progress=0.0f},
            };


            public static void SaveOngoing()
            {
                var json = JsonConvert.SerializeObject(Ongoing, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Achievements_Ongoing.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadOngoing()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Achievements_Ongoing.json");
                string output = File.ReadAllText(filename);
                List<AchievementItem> deserializedProduct = JsonConvert.DeserializeObject<List<AchievementItem>>(output);
                Ongoing = deserializedProduct;
            }
            public static void SaveDone()
            {
                var json = JsonConvert.SerializeObject(Done, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Achievements_Done.json");
                File.WriteAllText(filename, json);
            }
            public static void LoadDone()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Achievements_Done.json");
                string output = File.ReadAllText(filename);
                List<AchievementItem> deserializedProduct = JsonConvert.DeserializeObject<List<AchievementItem>>(output);
                Done = deserializedProduct;
            }
        }
        public static class SessionItems
        {
            public static List<SessionItem> Sessions = new List<SessionItem>();
            public static readonly SKColor[] myColors =
        {
            SKColor.Parse("#266489"),
            SKColor.Parse("#68B9C0"),
            SKColor.Parse("#90D585"),
            SKColor.Parse("#F3C151"),
            SKColor.Parse("#F37F64"),
            SKColor.Parse("#424856"),
            SKColor.Parse("#8F97A4"),
            SKColor.Parse("#DAC096"),
            SKColor.Parse("#76846E"),
            SKColor.Parse("#DABFAF"),
            SKColor.Parse("#A65B69"),
            SKColor.Parse("#97A69D"),
        };

            public static void Save()
            {
                var json = JsonConvert.SerializeObject(Sessions, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Sessions.json");
                File.WriteAllText(filename, json);
            }
            public static void Load()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "Sessions.json");
                string output = File.ReadAllText(filename);
                List<SessionItem> deserializedProduct = JsonConvert.DeserializeObject<List<SessionItem>>(output);
                Sessions = deserializedProduct;
            }

            public static void AddSession(SessionItem NewSession)
            {
                try { Load(); } catch { }
                Sessions.Add(NewSession);
                Save();
            }

            public static ChartEntry[] MakeData(nint SpanType)
            {
                var output = new List<ChartEntry>();
                DateTime now = DateTime.Now;
                TimeSpan span = new TimeSpan(7, 0, 0, 0);
                TimeSpan xrange = new TimeSpan();
                if (SpanType == 0)
                {
                    span = new TimeSpan(7,0,0,0);
                    xrange = new TimeSpan(1, 0, 0, 0);
                    
                }
                if (SpanType == 1)
                {
                    span = now.AddMonths(1) - now;
                    xrange = now.AddDays(7) - now;
                }
                if (SpanType == 2)
                {
                    span = now.AddYears(1) - now;
                    xrange = now.AddMonths(1) - now;
                }
                var selectedSessions = new List<SessionItem>();
                var CurrDate = DateTime.Now;
                int WeekNumber = CurrDate.Day / 7;
                int MonthNumber = CurrDate.Month;
                int YearNumber = CurrDate.Year;
                for (int i = 0; i < Sessions.Count(); i++)
                {
                    if (SpanType == 0)
                    {
                        if (now - Sessions[i].Date < span & WeekNumber == Sessions[i].Date.Day / 7)
                        {
                            selectedSessions.Add(Sessions[i]);
                        }
                    }
                    if (SpanType == 1)
                    {
                        if (now - Sessions[i].Date < span & MonthNumber == Sessions[i].Date.Month)
                        {
                            selectedSessions.Add(Sessions[i]);
                        }
                    }
                    if (SpanType == 2)
                    {
                        if (now - Sessions[i].Date < span & YearNumber == Sessions[i].Date.Year)
                        {
                            selectedSessions.Add(Sessions[i]);
                        }
                    }
                }
                /*
                for (int i = 0; i < Sessions.Count(); i++)
                {           
                    if (now - Sessions[i].Date < span)
                    {
                        //New version 
                        selectedSessions.Add(Sessions[i]);
                    }
                }
                */
                if (selectedSessions.Count() > 0)
                {
                    var duration = selectedSessions[0].Duration.TotalHours;
                    var first = selectedSessions[0];
                    var count = 0;
                    var label = "error";
                    for (int i = 1; i < selectedSessions.Count(); i++)
                    {
                        if (selectedSessions[i].Date - first.Date < xrange)
                        {
                            duration += selectedSessions[i].Duration.TotalHours;
                        }
                        else
                        {
                            if (SpanType == 0)
                            {
                                label = first.Date.ToString("dddd");
                            }
                            if (SpanType == 1)
                            {
                                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                                int dayNum = ciCurr.Calendar.GetDayOfMonth(first.Date);
                                int week = dayNum / 7;
                                label = "semaine " + week.ToString();

                            }
                            if (SpanType == 2)
                            {
                                label = first.Date.ToString("MMMM");
                            }
                            output.Add(new ChartEntry(Convert.ToSingle(duration))
                            {
                                Color = myColors[count % myColors.Count()],
                                Label = label,
                                ValueLabel = GetString(duration),
                            }) ;
                            duration = selectedSessions[i].Duration.TotalHours;
                            first = selectedSessions[i];
                            count += 1;
                        }
                    }
                    if (SpanType == 0)
                    {
                        label = first.Date.ToString("dddd");
                    }
                    if (SpanType == 1)
                    {
                        CultureInfo ciCurr = CultureInfo.CurrentCulture;
                        int dayNum = ciCurr.Calendar.GetDayOfMonth(first.Date);
                        int week = dayNum / 7;
                        label = "semaine " + week.ToString();
                    }
                    if (SpanType == 2)
                    {
                        label = first.Date.ToString("MMMM");
                    }
                    output.Add(new ChartEntry(Convert.ToSingle(duration))
                    {
                        Color = myColors[count % myColors.Count()],
                        Label = label,
                        ValueLabel = GetString(duration),
                    });
                }
                return output.ToArray();
            }
            public static List<int> GetHours()
            {
                List<int> output = new List<int>();
                DateTime now = DateTime.Now;
                int WeekNumber = now.Day / 7;
                int MonthNumber = now.Month;
                int YearNumber = now.Year;
                List<TimeSpan> Spans = new List<TimeSpan>() { new TimeSpan(), new TimeSpan(), new TimeSpan()};
                Spans[0] = now.AddDays(7) - now;
                Spans[1] = now.AddMonths(1) - now;
                Spans[2] = now.AddYears(5) - now;
                for (int i =0; i < Spans.Count(); i++)
                {
                    var count = 0.0;
                    for (int j = 0; j < Sessions.Count(); j++)
                    {
                        if (now - Sessions[j].Date < Spans[i] | i == 2)
                        {
                            if ( i == 0 & WeekNumber == Sessions[j].Date.Day / 7)
                            {
                                count += Sessions[j].Duration.TotalHours;
                            }
                            if ( i == 1 & MonthNumber == Sessions[j].Date.Month)
                            {
                                count += Sessions[j].Duration.TotalHours;
                            }
                            if ( i == 2)
                            {
                                count += Sessions[j].Duration.TotalHours;
                            }
                        }
                    }
                    output.Add(Convert.ToInt32(Math.Truncate(count)));
                    
                }
                return output;
            }
        }
        public static string GetString(double duration)
        {
            var hours = Convert.ToSingle(Math.Round(duration, 2));
            var min = hours - Math.Truncate(hours);
            min = min * 100;
            var hour = Math.Truncate(hours);
            if (min >= 60)
            {
                hour += 1;
                min = min - 60;
            }
            var valueLabel = hour.ToString() + " h " + Math.Truncate(min).ToString() + " m";
            return valueLabel;
        }
        public static class Coins
        {
            public static List<int> myCoins = new List<int>() { 0, 0 };
            public static void Save()
            {
                var json = JsonConvert.SerializeObject(myCoins, Newtonsoft.Json.Formatting.Indented);
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "myCoins.json");
                File.WriteAllText(filename, json);
            }
            public static void Load()
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "myCoins.json");
                string output = File.ReadAllText(filename);
                List<int> deserializedProduct = JsonConvert.DeserializeObject<List<int>>(output);
                myCoins = deserializedProduct;
            }
            public static void Add(int NewCoins)
            {
                myCoins[0] += NewCoins;
                myCoins[1] += NewCoins;
                Save();
            }
            public static void Substract(int Payment)
            {
                myCoins[0] -= Payment;
                Save();
            }
        }
        public static void ComputeAchievements()
        {
            // PreProcessing
            try { Inventory.LoadCats(); } catch { };
            try { Inventory.LoadPatterns(); } catch { };
            try { SessionItems.Load(); } catch { };
            try { Coins.Load();} catch { };
            AchievementItems.Ongoing = new List<AchievementItem>();
            AchievementItems.Done = new List<AchievementItem>();
            double TotalTime = 0;
            int MaxinRow = 0;
            var CurrinRow = 0;
            for (int i = 0; i < SessionItems.Sessions.Count(); i++)
            {
                TotalTime += SessionItems.Sessions[i].Duration.TotalHours;
                if (i > 0)
                {
                    var CurrDate = SessionItems.Sessions[i-1].Date;
                    var NextDate = SessionItems.Sessions[i].Date;
                    var ExpDate = SessionItems.Sessions[i].Date.AddDays(1);
                    var Test = (NextDate.Day == ExpDate.Day & NextDate.Month == ExpDate.Month & NextDate.Year == ExpDate.Year);
                    var Catch = (NextDate.Day == CurrDate.Day & NextDate.Month == CurrDate.Month & NextDate.Year == CurrDate.Year);
                    if ( Test == true)
                    {
                        CurrinRow += 1;
                        if (MaxinRow < CurrinRow)
                        {
                            MaxinRow = CurrinRow;
                        }
                    }
                    if (Catch == false)
                    {
                        CurrinRow = 0;
                    }
                }
            }
            // Partie 1 - Temps Total 
            List<int> Milestones = new List<int>() { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
            for (int i = 0; i < Milestones.Count(); ++i)
            {
                // Heures 16-25
                if (TotalTime >= Milestones[i])
                {
                    // Succès Faits 
                    AchievementItems.Done.Add(AchievementItems.All[16 + i]);

                }
                else
                {
                    //Calculer la progression & ajouter
                    double prog = (double)TotalTime / Milestones[i];
                    var ach = AchievementItems.All[16 + i];
                    ach.progress = prog;
                    AchievementItems.Ongoing.Add(ach);
                }
            }
            // Partie 2 -  Jours D'affilés
            List<int> MilestoneRow = new List<int>() { 2, 3, 5, 7, 10, 15, 20, 30, 60 };
            for (int i = 0; i < MilestoneRow.Count(); i++)
            {
                // Jours 7-15
                if (MaxinRow >= MilestoneRow[i])
                {
                    AchievementItems.Done.Add(AchievementItems.All[7 + i]);
                }
                else
                {
                    // Calculer la progression
                    double prog = (double)MaxinRow / MilestoneRow[i];
                    AchievementItem ach = AchievementItems.All[7 + i];
                    ach.progress = prog;
                    AchievementItems.Ongoing.Add(ach);

                }
            }
            // Partie 3 - Argent Gagné
            var TotalMoney = Coins.myCoins[1];
            List<int> MilestoneMoney = new List<int> {100, 1000, 2000, 5000, 10000, 50000, 100000 };
            for (int i = 0; i < MilestoneMoney.Count(); i++)
            {
                if (TotalMoney >= MilestoneMoney[i])
                {
                    // Succès faits
                    AchievementItems.Done.Add(AchievementItems.All[i]);
                }
                else
                {
                    // Calculer la progression
                    double prog = (double)AppData.Coins.myCoins[1] / MilestoneMoney[i];
                    AchievementItem ach = AchievementItems.All[i];
                    ach.progress = prog;
                    AchievementItems.Ongoing.Add(ach);
                }
            }
            // Partie 4 - Achats
            //Total
            var TotalItems = Inventory.Cats.Count() + Inventory.Patterns.Count();
            List<int> MilestoneTotalItems = new List<int> { 1, 3, 5, 10, 20, 40, 50, 80, 100 };
            for (int i = 0; i < MilestoneTotalItems.Count(); i++)
            {
                if (TotalItems >= MilestoneTotalItems[i])
                {
                    // Succès faits
                    AchievementItems.Done.Add(AchievementItems.All[33+i]);

                }
                else
                {
                    // Calculer la progression
                    var prog = (double)TotalItems / MilestoneTotalItems[i];
                    AchievementItem ach = AchievementItems.All[33+i];
                    ach.progress = prog;
                    AchievementItems.Ongoing.Add(ach);
                }

            }
            //Chats
            var TotalCats = Inventory.Cats.Count();
            List<int> MilestoneTotalCats = new List<int> { 1, 3, 5, 10, 20, 40, 50 };
            for (int i = 0; i < MilestoneTotalCats.Count(); i++)
            {
                if (TotalCats >= MilestoneTotalCats[i])
                {
                    // Succès faits
                    AchievementItems.Done.Add(AchievementItems.All[26 + i]);
                }
                else
                {
                    // Calculer la progression
                    double prog = (double)TotalCats / MilestoneTotalCats[i];
                    AchievementItem ach = AchievementItems.All[26 + i];
                    ach.progress = prog;
                    AchievementItems.Ongoing.Add(ach);
                }
            }
            //Patterns
            var TotalPatterns = Inventory.Patterns.Count();
            List<int> MilestoneTotalPatterns = new List<int> { 1, 3, 5, 10, 20, 40, 50 };
            for (int i = 0; i < MilestoneTotalPatterns.Count(); i++)
            {
                if (TotalPatterns >= MilestoneTotalPatterns[i])
                {
                    // Succès faits
                    AchievementItems.Done.Add(AchievementItems.All[42 + i]);

                }
                else
                {
                    // Calculer la progression
                    double prog = (double)TotalPatterns / MilestoneTotalPatterns[i];
                    AchievementItem ach = AchievementItems.All[42 + i];
                    ach.progress = prog;
                    AchievementItems.Ongoing.Add(ach);
                }
            }
            AchievementItems.Ongoing.Sort(AchievementCompare);
            AchievementItems.SaveDone();
            AchievementItems.SaveOngoing();
        }
        public static int AchievementCompare (AchievementItem x, AchievementItem y)
        {
            if (x.progress > y.progress)
            {
                return -1;
            }
            if (x.progress == y.progress)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}