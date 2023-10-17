def new_func():
    summ = 100
    return summ

summ = new_func()
for x in range(100):
    summ += summ/10
    print(summ)