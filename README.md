1. given：一个停车场，when：把停车场安排给小弟的时候，when：
1. given：一个有一个空位的停车场，有个停车小弟，车，when：让小弟停一辆车，then：给一个票
2. given：只有一个满位的停车场，停车小弟，车，when：让小弟停车，then：提示：没有地方
3. given：有两个停车场都有两个以上的空位，有个停车小弟，两个车，when：让小弟连着停两辆车，then：第一个停车场数量+2，第二个停车场数量不变
4. given：给合法的票，小弟，停车场中已经停了一个车了，when：让小弟取车，then：返回停的车
5. given：给非法的票，小弟，when：让小弟取车，then：提示：错误票据
6. given：有两个停车场，第一个停了自己的车，第二个没有，还有一张被小弟停了车的票，when：自己去取车，then：第一个返回车，第二个提示：取不到车
7. given：有两个停车场，第一个停了自己的车，第二个没有，还有一张被自己停了车的票，when：让小弟去取车，then：返回车
8. given：有两个停车场，第一个停了自己的车，第二个没有，还有一张被自己停了车的票，小弟只管理第二个车场，when：让小弟去取车，then：小弟说：我找不到
