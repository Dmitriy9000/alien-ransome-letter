package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func main() {
	result := SolveUsingMap()
	fmt.Println(result)
}

func SolveUsingMap() bool {
	reader := bufio.NewReader(os.Stdin) 

	var ransomeCodes = GetInput(reader); // O(N)

	// Edge case
	if (len(ransomeCodes) == 0)	{
		return true;
	}

	var magazineCodes = GetInput(reader); // O(M)

	// Edge case
	if (len(magazineCodes) == 0) {
		return false;
	}

	// If magazine codes count less than ransome codes count, then there is no reason to iterate over dictionary (`fail fast` optimization)
	if (len(magazineCodes) < len(ransomeCodes)) {
		return false;
	}

	for key, encounters := range ransomeCodes { // O(N)
		if (magazineCodes[key] < encounters) { // O(1)
			return false;
		}
	}

	return true;
}

// Populates the dictionary from user's input
// ['code1'] = number of encounters of code1
// ['code2'] = number of encounters of code2
// ...
func GetInput(reader *bufio.Reader) map[string]uint64 {
	
	lengthInput, _ := reader.ReadString('\n')

	length, error := strconv.ParseUint(strings.TrimSpace(lengthInput), 0, 64)
	if error != nil {
    log.Fatal(error)
	}

	var result map[string]uint64
	result = make(map[string]uint64)

	for length > 0 {
		nextSymbol, _ := reader.ReadString('\n')
		nextSymbol = strings.TrimSpace(nextSymbol)
		result[nextSymbol]++;
		length--;   
	}

	return result;
}