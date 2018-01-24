function solve(string) {

    let strUpper = string.toUpperCase();
    let words = extractWords();
    words = words.filter(w => w != '');
    return words.join(', ');

    function extractWords() { return strUpper.split(/\W+/); };
}