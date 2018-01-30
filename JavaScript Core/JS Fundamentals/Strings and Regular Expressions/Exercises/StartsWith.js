function solve(text,subs) {
     
    if (text.startsWith(subs)) {
       return true;
    }
    return false;

}
 solve('How have you been?','how');