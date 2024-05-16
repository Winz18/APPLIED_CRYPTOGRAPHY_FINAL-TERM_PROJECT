import time
import multiprocessing
from itertools import product, chain


def wordlist_with_number_phone():
    print("Start generating wordlist with number phone...")
    preflix = ['039','038','037','036','035','034',
              '033','032','096','097','098','086',
              '083','084','085','081','088','082',
              '070','079','077','076','078',
              ]
    with open("suffix.txt", "r") as f:
        suffix = f.read().split("\n")
    
    with open("wordlist_number_phone.txt", "w") as f: 
        for prefix, suf in product(preflix, suffix):
            number = prefix + suf
            f.write(number + "\n")  # Ghi từng số điện thoại vào file
    print("[bold green]Done generating wordlist with number phone...[/bold green]")
    
def wordlist_with_name(flag_name):
    first_names = ['nguyen','le','bui','pham','tran','vu','dang','do','ho','bui','ngo','huynh','ly','luong','mai','cao','truong']
    last_names =['an', 'bao', 'binh', 'dat', 'duc', 'dung', 'duy', 'gia', 'huy', 'khanh', 'khoa', 'kiet', 'lam', 'linh',
                  'loc', 'long', 'minh', 'ngoc', 'nhan', 'phong', 'phu', 'phuc', 'quang', 'quoc', 'sang', 'son', 'thang']
    middle_names = ['thi','van']
    print("Start generating wordlist with name...")
    with open("wordlist_name.txt", "w") as f:  
        for first, middle, last in chain(product(first_names, middle_names, last_names), product(first_names, last_names, last_names)):
            full_name = first + middle + last
            f.write(full_name + "\n")  # Ghi từng tên vào file
    print("[bold green]Done generating wordlist with name...[/bold green]")
    flag_name.set()

def common_wordlist():
    print("Start generating common wordlist...")
    s=""
    f=open("wordlist_common.txt", "w")
    #1->9
    for i in range(1,10):
        s+=str(i)
        if(len(s)>=8):
            f.write(s+'\n')
    s=""
    for i in range(9,-1,-1):
        s+=str(i)
        if(len(s)>=8):
            f.write(s+'\n')
    #0->9
    s=""
    for i in range(0,10):
        s+=str(i)
        if(len(s)>=8):
            f.write(s+'\n')
    f.write('12345678910'+'\n')
    #abababab+aaaaaaaa
    s=""
    for i in range(0,10):
        for j in range(0,10):
            s1=str(i)
            s2=str(j)
            s=""
            for ki in range(4):
                s+=s1+s2
            f.write(s+'\n')
    #'a'*10
    for i in range(ord('a'),ord('z')+1):
        f.write(chr(i)*10+'\n')
    for i in range(0,9):
        f.write(str(i)*10+'\n')
    #'abc'*3
    for i in range(0,10):
        for j in range(0,10):
            for k in range(0,10):
                s=str(i)+str(j)+str(k)
                s=s*3
                if(i!=j and j!=k):
                    f.write(s+'\n')
    print("[bold green]Done generating common wordlist...[/bold green]")
    f.close()

def wordlist_birthday(flag_birth):
    print("Start generating wordlist with birthday...")
    with open("wordlist_birthday1.txt", "w") as f:
        for i in range(1970,2024):
            for j in range(1,13):
                for k in range(1,32):
                    s=str(k).zfill(2)+str(j).zfill(2)+str(i)
                    f.write(s+'\n')
    flag_birth.set()
    print("[bold green]Done generating wordlist with birthday...[/bold green]")

def wordlist_birth_and_name(flag_birth, flag_name):
    last_names =['an', 'bao', 'binh', 'dat', 'duc', 'dung', 'duy', 'gia', 'huy', 'khanh', 'khoa', 'kiet', 'lam', 'linh',
                  'loc', 'long', 'minh', 'ngoc', 'nhan', 'phong', 'phu', 'phuc', 'quang', 'quoc', 'sang', 'son', 'thang']
    print("Start generating wordlist with birthday and name...")
    flag_birth.wait()
    flag_name.wait()
    with open("wordlist_birth_and_name.txt", "w") as f:
        with open("wordlist_birthday1.txt", "r") as f1:
            for name, birth in product(last_names, f1):
                password = name + birth[4:]
                password = password.replace("\n", "")
                if len(password) < 8:
                    first = name
                    for last in last_names:
                        password = first + last + birth[4:]
                        password = password.replace("\n", "")
                        f.write(password + "\n")
                else:
                    f.write(password + "\n")
    print("[bold green]Done generating wordlist with birthday and name...[/bold green]")


if __name__ == "__main__":
    start = time.time()
    flag_birth = multiprocessing.Event()
    flag_name = multiprocessing.Event()
    Process = [
        multiprocessing.Process(target=wordlist_with_number_phone),
        multiprocessing.Process(target=wordlist_with_name, args=(flag_name,)),
        multiprocessing.Process(target=common_wordlist),
        multiprocessing.Process(target=wordlist_birthday, args=(flag_birth,)),
        multiprocessing.Process(target=wordlist_birth_and_name, args=(flag_birth, flag_name))
    ]
    
    for p in Process:
        p.start()
    for p in Process:
        p.join()
    print("Main done")
    print("Time to generate wordlist: ", time.time() - start)