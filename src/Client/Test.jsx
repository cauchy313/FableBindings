import React from "react";
import {VictoryChart, VictoryLabel, VictoryLine, VictoryScatter } from "victory";


// const DataLabel = props => {
//     const x = props.scale.x(props.x);
//     const y = props.scale.y(props.y);
//     return <VictoryLabel {...props} x={x} y={y}/>
//   };

//const data = React.createElement(DataLabel, {x: 5, y: 5, dy: 10, text : "a custome data coordinate label"})

export  const MyChart = () => {
    return (
      <VictoryChart domain={ [0, 10]}>
        <VictoryLine />
        <VictoryScatter data={[{ x: 5, y: 5 }]} />
        
        <VictoryLabel 
              x = {prop}
        />
       {/* <DataLabel
          x={5}
          y={5}
          dy={10}
          text="a custom data coordinate label"
        /> */}
        <VictoryLabel
          x={55}
          y={50}
          text="an svg coordinate label"
        />
      </VictoryChart>
    );
  };