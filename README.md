# יצירת פרוייקט חדש
פתחו את תיקיית הפרוייקטים שלכם והריצו את הפקודה הבאה (וודאו להחליף את [your project name] בשם הפרוייקט שלכם):
```
git clone https://github.com/Computer-Engineering-Major-Ort-Ariel/WebTemplate [your project name]
```

# הרצת הפרוייקט

על מנת להריץ את השרת מבלי להצטרך לפתוח את סביבת הפיתוח כמנהל, ניתן לאפשר גישה לפורט רצוי (במקרה שלנו, פורט 5000) בעזרת פתיחת שורת המשימות כמנהל והרצת הפקודה:

```
netsh http add urlacl url=http://*:5000/ user=Everyone
```
לאחר מכן נפתח את סביבת הפיתוח ונריץ את הפרוייקט בעזרת הפקודה:
```
dotnet run
```
# מערכת יצירת משתמש \ התחברות למשתמש
![user_system](https://github.com/user-attachments/assets/6ec4c932-cf9c-470b-9d20-6e6c4254de33)
