from copy import deepcopy
import glob
import sys
from matplotlib.colors import LogNorm
from pylab import *
import numpy as np

def line( x0, y0, x1, y1):
    #"Bresenham's line algorithm"
    toReturn = []
    dx = abs(x1 - x0)
    dy = abs(y1 - y0)
    x, y = x0, y0
    sx = -1 if x0 > x1 else 1
    sy = -1 if y0 > y1 else 1
    if dx > dy:
        err = dx / 2.0
        while x != x1:
            toReturn.append([x, y])
            err -= dy
            if err < 0:
                y += sy
                err += dx
            x += sx
    else:
        err = dy / 2.0
        while y != y1:
            toReturn.append([x, y])
            err -= dx
            if err < 0:
                x += sx
                err += dy
            y += sy        
    toReturn.append([x, y])
    return toReturn

def readDataToPaths(name):
    

    t = name
    xs = []
    ys = []
    
    for d in t:
        d = open(d)
        


        #want to grab the position information 
        
        d = list(d)
        a =[]

        for i,v in enumerate(d): 
            if "Pos:" in v:
                v = d[i+1]
                a = eval( v )
        
        for i,v in enumerate(a):
                
            if i+1 == len(a):
                break 
            output = line(int(v[0]),int(v[2]),int(a[i+1][0]),int(a[i+1][2]))
            #print"point"
            for point in range(len(output)-1):
                point = output[point]
                xs.append(point[0])
                ys.append(point[1])

    # for i in a:
    #     xs.append(i[0])
    #     ys.append(i[2])

    # print mapData
    #produce mapData
    maxX = int(max(xs))
    maxY = int(max(ys))
    
    minX = int(min(xs))
    minY = int(min(ys))

    # print minX,maxX
    # print minY,maxY
    # print "---"

    mapData = [[0 for _ in range (maxY+1)] for _ in range(maxX+1)]

    for i,v in enumerate(xs): 

        # print xs[i],ys[i]
        # print len(mapData),len(mapData[0])
        # print "--"
        mapData[int(xs[i])][int(ys[i])] +=1

    maxValue = 0
    for i in mapData:
        for j in i:
            if maxValue<j:
                maxValue=j
    # print maxValue
    mapDataR = [[0.0 for _ in range (maxY+1)] for _ in range(maxX+1)]

    for j,v1 in enumerate(mapData):
        for i, v2 in enumerate(v1):
            v = float(v2)/float(maxValue)
            mapDataR[j][i] = v
            if v2>maxValue:
                print v2
    # print mapDataR     
    return mapDataR

#This code will read and plot the heatmaps

f = "Data/"

t = glob.glob(f+"*.txt")


#Create the 3 classes
f = [[],[],[]]

for i in t:
    d = open(i)
    #skip first line
    d.next()

    f[int(d.next()[7])-1].append(i)
c = 1
for d in f:
    a = []
    a = readDataToPaths(d)               

    aFinal = np.array(a)
    # print aFinal
    aFinal = np.rot90(aFinal)

    clf()
    imshow(aFinal,cmap="Blues",interpolation="nearest",norm=LogNorm())
    # imshow(a[0],cmap="Reds",interpolation="nearest",norm=LogNorm())
    # title("Nb paths:"+ str(a[1]))
    axis("off")
    # f = f.replace(".txt",".pdf")
    savefig("output/AllHeatMap_n="+str(len(d))+"_level_"+str(c)+".pdf",bbox_inches='tight')
    # show()
    c+=1








