import re

generatorToNumber = {}
with open("input.txt", "r") as genFile:
    for line in genFile.readlines():

        pattern = "Generator ([A|B]) starts with (\d+)\n$"
        regexObject = re.compile(pattern)
        result = regexObject.match(line)

        groups = result.groups()
        generatorToNumber[groups[0]] = int(groups[1])

generatorToFactor = {
    "A": 16807,
    "B": 48271
}

generatorToRequiredMultiple = {
    "A": 4,
    "B": 8
}

totalMatching = 0
modulusDivisor = 2147483647

numberOfPairsToGenerate = 5000000
for pair in range(numberOfPairsToGenerate):
    for generator in generatorToNumber:
        while True:
            number = generatorToNumber[generator]
            multedNumber = number * generatorToFactor[generator]
            modulusMultedNumber = multedNumber % modulusDivisor
            generatorToNumber[generator] = modulusMultedNumber
            if generatorToNumber[generator] % generatorToRequiredMultiple[generator] == 0:
                break

    binaryNumbersToJudge = []
    for generator, number in generatorToNumber.items():
        binaryNumber = bin(number)
        binaryNumberWithoutPrefix = binaryNumber[2:]
        binaryNumbersToJudge.append(binaryNumberWithoutPrefix)

    allMatch = True
    substringToCompare = None
    numberOfBitsToMatch = 16
    for binaryNumber in binaryNumbersToJudge:
        paddedBinaryNumber = binaryNumber.zfill(numberOfBitsToMatch)
        if substringToCompare is None:
            substringToCompare = paddedBinaryNumber[-numberOfBitsToMatch:]
        else:
            currentBinaryToCompare = paddedBinaryNumber[-numberOfBitsToMatch:]
            allMatch = allMatch and substringToCompare == currentBinaryToCompare

    totalMatching += 1 if allMatch else 0

print("Final count of {} pairs matching is {}".format(numberOfPairsToGenerate, totalMatching))
