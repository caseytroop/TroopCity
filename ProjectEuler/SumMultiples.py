# Project Euler problem 1
# If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
# The sum of these multiples is 23.
# Create a script that takes 3 integers as arguments: topNum, mult1, mult2 and sums all the multiples of mult1 and mult2 below topNum.

def sumMultiples(topNum,mult1,mult2):
    sum = 0
    for i in range(topNum):
        if i % mult1 == 0 or i % mult2 == 0:
            sum += i
    return sum

# Read in the 3 integers from the command line
topNum = int(input("Enter the top number: "))
mult1 = int(input("Enter the first multiple: "))
mult2 = int(input("Enter the second multiple: "))
print("The sum of all multiples of ",mult1," and ",mult2," below ",topNum," is ",sumMultiples(topNum,mult1,mult2))
