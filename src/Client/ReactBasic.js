import React from "react";
import { VictoryBar } from 'victory';

const e = React.createElement;

export const title = ()  => React.createElement('h1', {}, 'My First React Code');

const paragraph = React.createElement('p', {}, 'Writing some more HTML. Cool stuff!');

export const container = () => React.createElement('div', [], React.createElement(VictoryBar, {}, null) );



export const list = () =>
  React.createElement('div', {},
    React.createElement('h1', {}, 'My favorite ice cream flavors'),
    React.createElement('ul', {},
      [
        React.createElement('li', { className: 'brown' }, 'Chocolate'),
        React.createElement('li', { className: 'white' }, 'Vanilla'),
        React.createElement('li', { className: 'yellow' }, 'Banana')
      ]
    )
  );