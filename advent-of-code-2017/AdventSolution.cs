namespace advent_of_code_2017
{
    [TestFixture]
    public abstract class AdventSolution
    {
        private long _expected;
        private long _actual;

        private long _exampleExpected;
        private long _inputExpected;

        private bool _wasExpectedMethodCalled;

        [SetUp]
        public void Setup()
        {
            fileCheckAssertions();
        }

        private void fileCheckAssertions()
        {
            Assert.That(File.Exists(getFilename(InputType.Example)), "Example file does not exist");
            Assert.That(File.Exists(getFilename(InputType.Input)), "Input file does not exist");
        }

        [Test]
        [TestCase(InputType.Example)]
        [TestCase(InputType.Input)]
        public void Part1(InputType inputType) =>
            Assert.That(() =>
            part(
                inputType,
                part1Work,
                part1ExampleExpected,
                part1InputExpected),
            Throws.Nothing);


        [Test]
        [TestCase(InputType.Example)]
        [TestCase(InputType.Input)]
        public void Part2(InputType inputType) =>
            Assert.That(() =>
            part(
                inputType,
                part2Work,
                part2ExampleExpected,
                part2InputExpected),
            Throws.Nothing);

        protected abstract long part1Work(string[] input);
        protected void part1Expected(
            long exampleExpected,
            long inputExpected)
        {

        }

        protected void part2Expected(
            long exampleExpected,
            long inputExpected)
        {

        }

        private void expected(
            long exampleExpected,
            long inputExpected)
        {
            _exampleExpected = exampleExpected;
            _inputExpected = inputExpected;
            _wasExpectedMethodCalled = true;
        }

        protected abstract long part1ExampleExpected { get; }
        protected abstract long part1InputExpected { get; }

        protected abstract long part2Work(string[] input);
        protected abstract long part2ExampleExpected { get; }
        protected abstract long part2InputExpected { get; }



        private void part(
            InputType type,
            Func<string[], long> workMethod,
            long exampleExpected,
            long inputExpected)
        {
            var answer = workMethod.Invoke(getInput(type));

            switch (type)
            {
                case InputType.Example:
                    assertions(exampleExpected, answer);
                    break;
                case InputType.Input:
                    assertions(inputExpected, answer);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void assertions(
            long expected,
            long actual)
        {
            _expected = expected;
            _actual = actual;

            Assert.That(expected == actual, $"Expected {expected}; actual {actual}");
        }

        private string[] getInput(InputType inputType)
        {
            return File.ReadAllLines(
                getFilename(inputType)
            );
        }

        private string getFilename(InputType inputType)
        {
            return
                this.GetType().Name
                + Path.DirectorySeparatorChar
                + inputType.ToString()
                + ".txt";
        }

        public enum InputType { Example, Input };
    }
}