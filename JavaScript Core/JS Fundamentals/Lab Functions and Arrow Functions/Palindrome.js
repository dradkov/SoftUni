function solve(word) {

    let first = word.substring(0, Math.floor(word.length/2));

    let second = word.substring(Math.floor(word.length/2),word.length);
  
    let secondReversed = reverse(second);

    function reverse(s) {
        return s.split('').reverse().join('');
      }

      if (first===secondReversed) {
          return true;
      }
      return false
}

solve('haha');