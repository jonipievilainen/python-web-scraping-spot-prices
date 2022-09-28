import csv
import json
import requests
from bs4 import BeautifulSoup

URL = "https://sahko.tk/"
page = requests.get(URL)
Soup = BeautifulSoup(page.text, "html.parser")

rawJ = Soup.find_all('script')
J = str(rawJ[9])
J1 = J.split('var data1= ')
J2 = J1[1].rsplit(';function', 1)
J3 = J2[0].rsplit(',data2', 1)
# print(J3[0])
obj1 = json.loads(J3[0])
# print(obj1)

csvs = ""
p_header = ['name', 'price']


# TODO: Continue here!
with open('data.csv', 'w') as file:
    writer = csv.writer(file)
    writer.writerow(p_header)
    writer.writerows(obj1)


# for pair in obj1:
#     for idx, value in enumerate(pair):
#         if idx == 0:
#             csvs += str(value) + '|'
#         else:
#             csvs += str(value)


