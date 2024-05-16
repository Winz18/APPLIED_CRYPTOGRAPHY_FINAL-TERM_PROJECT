with open("suffix.txt", "w") as f:
    for i in range(0,9999999+1):
        s=str(i).zfill(7)
        f.write(s+'\n')